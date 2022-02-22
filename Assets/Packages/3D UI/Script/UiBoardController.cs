using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiBoardController : MonoBehaviour {

    private Animator _animator;
    protected bool _open = false;

    protected virtual void Start() {
        _animator = GetComponent<Animator>();
        _animator.Play("3DUIBoardOpen_Reversed");
        _open = false;
    }

    protected virtual void Update() {

    }

    public virtual void ToggleBoard() {
        if (!_open){
            _animator.Play("3DUIBoardOpen");
            _open = true;
        } else {
            _animator.Play("3DUIBoardOpen_Reversed");
            _open = false;
        }
    }

    public virtual void FinishedOpenAnimation() {

    }
}
