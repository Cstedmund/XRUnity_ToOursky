using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSphereBtn : ClickableObject
{
    [SerializeField]
    Transform _Destination;

    protected override void OnPointerClick() {
        Camera.main.GetComponent<VRFader>().ChangeSphere(_Destination);
    }
}
