using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    private StoryManager storyManager;

    protected virtual void Awake() {
        storyManager = GameObject.FindObjectOfType<StoryManager>();
    }

    [SerializeField]
    private TextAsset conversation;
    protected bool dialogueStateComplete;

    protected virtual void OnEnable() {
        SetDialogueStateComplete();
        storyManager.EnterDialogueMode(conversation, dialogueStateComplete, Callback, OnDialogueFinshed);
    }

    protected virtual void SetDialogueStateComplete() {
        if(dialogueStateComplete) { return; }
        dialogueStateComplete = false;
    }

    protected virtual void Callback() {}

    protected virtual void OnDialogueFinshed() {}

    public virtual void OnCall() {
        SetDialogueStateComplete();
        storyManager.EnterDialogueMode(conversation,dialogueStateComplete,Callback,OnDialogueFinshed);
    }

    private void OnDisable() {
        storyManager.ToggleDialogueUI(false);
    }
}
