using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyController : MonoBehaviour {
    [SerializeField]
    public BookDB bookDB;
    [SerializeField]
    private GameObject lobbyCanvas;

    private GameManager gameManager;

    private void Awake() {
    }

    private void Start() {
        gameManager = GameManager.Instance;
    }

    public void ExternalLoadBook(string bookid) {
        gameManager.currentBook = bookDB.booksDict[bookid];
    }

    public void ExternalSetLandguage(string landIndexStr) {
        int landIndex;
        bool isParsable = int.TryParse(landIndexStr, out landIndex);
        if (isParsable) {
            switch (landIndex) {
                case 0:
                    gameManager.currentLanguage = GameManager.Language.en;
                    break;
                case 1:
                    gameManager.currentLanguage = GameManager.Language.zh;
                    break;
                default:
                    break;
            }
        }
        lobbyCanvas.GetComponent<LobbyCanvasManager>().UpdateLobbyUI();
    }

    public void LoadScene() {
        SceneManager.LoadScene(gameManager.currentBook.sceneName);
    }

    public void CallURL(string url) {
        Application.OpenURL(url);
    }

    public void UnloadUnity() {
        Application.Unload();
    }

    public void QuitUnity() {
        Application.Quit();
    }

    //============================================================================
    //public void ExternalLoadScene(string levelIndexString) {
    //    int levelindex;
    //    bool isParsable = int.TryParse(levelIndexString, out levelindex);
    //    if (isParsable) {
    //        switch (levelindex) {
    //            case 0:
    //                Debug.Log($"Load level index {levelindex}");
    //                SceneManager.LoadScene("GeogBook1");
    //                break;
    //            case 1:
    //                Debug.Log($"Load level index {levelindex}");
    //                SceneManager.LoadScene("GeogBook2");
    //                break;
    //            default:
    //                Debug.Log("No level index" + levelindex);
    //                break;
    //        }
    //    } else {
    //        Debug.Log("Pass in parameter is not Int String");
    //    }
    //}

    //public void ExternalPassString(string message) {
    //    print($"The message from xcode is: {message}");
    //}
}
