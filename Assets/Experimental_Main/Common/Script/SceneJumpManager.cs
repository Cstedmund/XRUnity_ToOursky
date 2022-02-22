using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJumpManager : MonoBehaviour
{
    public void InternalLoadScene(string sceneName) {
        if ((sceneName == "") & (GameManager.Instance.previousScene != null)) {
            Debug.Log($"Scene load {GameManager.Instance.previousScene}");
            SceneManager.LoadScene(GameManager.Instance.previousScene);
            return;
        }

        Debug.Log($"Scene load {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
