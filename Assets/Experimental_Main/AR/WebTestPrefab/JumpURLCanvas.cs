using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpURLCanvas : MonoBehaviour
{
    public void JumpURLByButton(string url) {
        Application.OpenURL(url);
    }
}
