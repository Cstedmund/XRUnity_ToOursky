using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image7interaction : MonoBehaviour
{

    [SerializeField]
    AudioSource backgroundMusic;
    [SerializeField]
    private GameObject rotateObject;
    [SerializeField]
    private float rotationalSpeed = 0.2f;

    private Vector3 previousPos = Vector3.zero, deltaPos = Vector3.zero;
    private bool dragging = false;

    void Start() {
        backgroundMusic.volume = 1f;
    }

    private void OnEnable() {
        backgroundMusic.volume = 1f;
    }

    private void OnDisable() {
        backgroundMusic.volume = 0f;
    }

    public void BeginDrag() {
        previousPos = Input.mousePosition;
        dragging = true;
    }

    public void OnPointerUp() {
        dragging = false;
    }

    private void Update() {
        if(dragging) {

            deltaPos = Input.mousePosition - previousPos;
            if(Vector3.Dot(transform.up,Vector3.up) >= 0) {
                rotateObject.transform.Rotate(transform.up,-Vector3.Dot(deltaPos,Camera.main.transform.transform.right) * rotationalSpeed,Space.World);
            } else {
                rotateObject.transform.Rotate(transform.up,Vector3.Dot(deltaPos,Camera.main.transform.transform.right) * rotationalSpeed,Space.World);
            }
            rotateObject.transform.Rotate(Camera.main.transform.right,Vector3.Dot(deltaPos,Camera.main.transform.up) * rotationalSpeed,Space.World); // sth like sin cos (Dot: Dot product)
            previousPos = Input.mousePosition;
        }
    }


}
