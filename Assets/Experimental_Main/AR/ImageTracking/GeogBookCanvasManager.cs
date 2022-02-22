using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GeogBookCanvasManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bottomLeftBookTitle,currentSceneName,currentImageName;

    private GameManager gameManager;
    private TrackedImageManager trackedImageManager;
    
    // Start is called before the first frame update
    void Start()
    {
        FunctionLibrary.SetDeviceOrientation(orientation: FunctionLibrary.Orientation.Portrait, autoRotate: false);
        gameManager = GameManager.Instance;
        if (!gameManager.debugOn) {
            currentSceneName.GetComponentInParent<GameObject>().SetActive(gameManager.debugOn);
            currentImageName.GetComponentInParent<GameObject>().SetActive(gameManager.debugOn);
        }
        trackedImageManager = GameObject.FindObjectOfType<TrackedImageManager>().GetComponent<TrackedImageManager>();

        if (gameManager.debugOn)
            currentSceneName.text = SceneManager.GetActiveScene().name;

        switch (gameManager.currentLanguage) {
            case (GameManager.Language.en):
                bottomLeftBookTitle.SetText(gameManager.currentBook.chapterNumber + " " + gameManager.currentBook.bookName);
                break;
            case (GameManager.Language.zh):
                bottomLeftBookTitle.SetText(gameManager.currentBook.chapterNumber + " " + gameManager.currentBook.bookNameCn);
                break;
            default:
                break;
        }
    }

    private void FixedUpdate() {
        if (gameManager.debugOn)
            currentImageName.text = trackedImageManager.currentImageName;
    }
}
