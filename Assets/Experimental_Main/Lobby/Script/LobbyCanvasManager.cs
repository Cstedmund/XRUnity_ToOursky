using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARSubsystems;
#if UNITY_IOS
using UnityEngine.XR.ARKit;
#endif
using UnityEngine.XR.Management;

public class LobbyCanvasManager : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI bookNo, bookName, selectModeText;
    [SerializeField]
    private Image secondTopBarImg;
    [SerializeField]
    private Transform modeContainer;
    [SerializeField]
    private Sprite secTopBarSprite;

    private GameManager gameManager;
    private GameObject arBodyTrackBtn;

    private void Awake() {
        gameManager = GameManager.Instance;
    }

    private void Start() {

        FunctionLibrary.SetDeviceOrientation(orientation: FunctionLibrary.Orientation.Portrait, autoRotate: false);
        arBodyTrackBtn = null;

#if UNITY_IOS
        StatusBarManager.Show(true);
        StatusBarManager.BarStyle(1);
#endif
        UpdateLobbyUI();
    }

    public void UpdateLobbyUI() {
        foreach (Transform child in modeContainer) {
            child.gameObject.SetActive(false);
        }
        secondTopBarImg.sprite = secTopBarSprite;
        secondTopBarImg.color = new Color(120f / 255f, 127f / 255f, 189f / 255f);
        bookNo.SetText(gameManager.currentBook.chapterNumber);

        switch (gameManager.currentLanguage) {
            case (GameManager.Language.en):
                bookName.text = gameManager.currentBook.bookName;
                selectModeText.SetText("Please select module:");
                break;
            case (GameManager.Language.zh):
                bookName.text = gameManager.currentBook.bookNameCn;
                selectModeText.SetText("請選擇使用模式：");
                break;
            default:
                break;
        }

        foreach (BookItem.BookModeType mode in gameManager.currentBook.mode) {
            switch (mode) {
                case (BookItem.BookModeType.AR):
                    foreach (Transform child in modeContainer) {
                        if (child.name == "AR") {
                            child.gameObject.SetActive(true);
                        }
                    }
                    break;
                case (BookItem.BookModeType.VR):
                    foreach (Transform child in modeContainer) {
                        if (child.name == "VR") {
                            child.gameObject.SetActive(true);
                        }
                    }
                    break;
                case (BookItem.BookModeType.WebResources):
                    foreach (Transform child in modeContainer) {
                        if (child.name == "WebResources") {
                            child.gameObject.SetActive(true);
                        }
                    }
                    break;
                case (BookItem.BookModeType.ARBodyTrack):
                    foreach (Transform child in modeContainer) {
                        if (child.name == "ARBodyTrack") {
                            child.gameObject.SetActive(true);
                            child.gameObject.GetComponent<Button>().interactable = false;
                            arBodyTrackBtn = child.gameObject;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        //check body track support?
        var bodyTrackingDescriptors = new List<XRHumanBodySubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(bodyTrackingDescriptors);
        if (bodyTrackingDescriptors.Count > 0 && (arBodyTrackBtn != null)) {
            foreach (var bodyTrackingDescriptor in bodyTrackingDescriptors) {
                if (bodyTrackingDescriptor.supportsHumanBody2D || bodyTrackingDescriptor.supportsHumanBody3D) {
                    foreach (Transform child in modeContainer) {
                        if (child.name == "ARBodyTrack") {
                            child.gameObject.GetComponent<Button>().interactable = true;
                        }
                    }
                }
            }
        }
    }
}
