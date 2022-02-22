using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToWebView : MonoBehaviour
{
    public void SetDataForWebView(string url) {
        GameManager.Instance.currentURL = url;
        GameManager.Instance.previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("WebView");
    }
}
