using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.Video;
using TMPro;

public class StoryManager : MonoBehaviour {
    //private static StoryManager _instance;

    //public static StoryManager Instance {
    //    get { return _instance; }
    //}

    private TrackedImageManager trackedImageManager;
    private GameManager gameManager;

    private void Awake() {
        //if(_instance != null && _instance != this) {
        //    Destroy(gameObject);
        //} else {
        //    _instance = this;
        //}
        trackedImageManager = GameObject.FindObjectOfType<TrackedImageManager>();
    }
    [SerializeField]
    private GameObject dialogueCanvas, dialogueBox, continousSignObject;
    [SerializeField]
    private Transform optionsContainer;
    [SerializeField]
    private TextMeshProUGUI contentDialogue;

    public Action callback, onFinished;

    private bool dialogueIsPlaying;
    private Story currentStory;
    

    public bool isRedOption;

    private void Start() {
        ToggleDialogueUI(false);
        isRedOption = false;

        gameManager = GameManager.Instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON,bool dialogueStateComplete,Action callback = null,Action onFinished = null) {
        currentStory = new Story(inkJSON.text);

        this.onFinished = onFinished;
        this.callback = callback;
        currentStory.BindExternalFunction("callback",() => {
            if(callback != null) {
                callback();
            }
        });

        if(currentStory.canContinue) {
            if(dialogueStateComplete) {
                currentStory.variablesState["finshedDialogue"] = dialogueStateComplete;
            }
            if(currentStory.variablesState["missionPass"] != null) {
            }
            if(currentStory.variablesState["choiceIsRed"] != null) {
                currentStory.variablesState["choiceIsRed"] = isRedOption;
            }
            ContinousStory();
        } else {
            ExitDialogueMode();
        }
    }

    public void ContinousStory() {

        if(!currentStory.canContinue && currentStory.currentChoices.Count == 0) {
            ExitDialogueMode();
            return;
        }

        ToggleDialogueUI(true,(string)currentStory.variablesState["speakerName"],currentStory.Continue());

        if(currentStory.canContinue && currentStory.currentChoices.Count == 0) {
            dialogueBox.GetComponent<Button>().interactable = currentStory.canContinue;
            continousSignObject.SetActive(currentStory.canContinue);
            continousSignObject.GetComponent<TextMeshProUGUI>().text = ">>";
            //dialogueBox.GetComponentInChildren<Text>().text = ">>";
        } else {
            if(currentStory.currentChoices.Count != 0) {
                dialogueBox.GetComponent<Button>().interactable = currentStory.canContinue;
                continousSignObject.SetActive(false);
            } else {
                dialogueBox.GetComponent<Button>().interactable = true;
                continousSignObject.SetActive(true);
                continousSignObject.GetComponent<TextMeshProUGUI>().text = "X";
                //dialogueBox.GetComponentInChildren<Text>().text = "X";
            }
        }

        //Tag display test
        if(currentStory.currentTags.Count != 0) {
            //Debug.Log("tags " + currentStory.currentTags[0]);
        }
        ToggleDisplayOption(currentStory.currentChoices.Count > 0,currentStory.currentChoices);
    }

    private void ExitDialogueMode() {
        if((bool)currentStory.variablesState["finshedDialogue"] && (onFinished != null)) {
            onFinished();
        }
        trackedImageManager.enabled = true;
        ToggleDialogueUI(false);
    }

    public void ToggleDialogueUI(bool toggle,string name = "",string content = "") {
        dialogueCanvas.SetActive(toggle);
        dialogueIsPlaying = toggle;
        contentDialogue.text = content;
    }

    #region Options
    public void MakeChoices(Transform choice) {
        currentStory.ChooseChoiceIndex(choice.GetSiblingIndex());
        ContinousStory();
    }

    private void ToggleDisplayOption(bool toggle,List<Choice> choices = null) {
        optionsContainer.gameObject.SetActive(toggle);

        if(!toggle) { return; }

        for(int i = 0; i < Mathf.Max(choices.Count,optionsContainer.childCount); i++) {
            if(i < optionsContainer.childCount) {
                optionsContainer.GetChild(i).gameObject.SetActive(i < choices.Count);

                if(i < choices.Count) {
                    optionsContainer.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = choices[i].text;
                }
            }
        }
    }
    #endregion
}
