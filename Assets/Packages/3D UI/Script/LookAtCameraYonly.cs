using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraYonly : MonoBehaviour
{
    private Camera cameraToLookAt;

    void Start() {
        //transform.Rotate( 180,0,0 );
        cameraToLookAt = Camera.main;
    }

    void Update() {
        //Vector3 v = cameraToLookAt.transform.position - transform.position;
        //v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position);
        transform.Rotate(0, 180, 0);
    }
}
