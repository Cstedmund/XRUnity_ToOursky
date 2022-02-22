using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour {
    private Animator gazeAnimator;
    private CameraPointer cameraPointer;
    [HideInInspector]
    public bool gazeHover;

    private void Start() {
        gazeAnimator = GetComponent<Animator>();
        gazeHover = false;
        cameraPointer = FindObjectOfType<CameraPointer>();
    }

    virtual public void GazeHoverOnEnter() {
        gazeAnimator.Play("GazeHoverEnter");
        gazeHover = true;
        gazeAnimator.SetBool("HoverLeave", false);
        StartCoroutine("StartHoverTimer");
    }

    private IEnumerator StartHoverTimer() {
        yield return new WaitForSecondsRealtime(2f);
        if (gazeHover) {
            GazeHoverWait();
        }
    }

    private void GazeHoverWait() {
        gazeAnimator.Play("WaitingHover");
    }

    virtual public void CallGazeClick() {
        gazeAnimator.Play("GazeClick");
    }

    virtual public void GazeOnClick() {
        Debug.Log("OnClick");
        cameraPointer.hoverClick = true;
        ResetGaze();
    }

    virtual public void GazeOnLeave() {
        gazeHover = false;
        gazeAnimator.SetBool("HoverLeave", true);
    }

    public void ResetGaze() {
        gazeHover = false;
        gazeAnimator.SetBool("HoverLeave", false);
    }
}
