using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;

public class VRPlayerController : MonoBehaviour {
    [SerializeField]
    private float playerSpeed;

    private bool _isScreenTouched {
        get { return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary; }
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (_isScreenTouched) {
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        }
    }
}
