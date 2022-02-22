using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScreen : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        FunctionLibrary.SetDeviceOrientation(orientation: FunctionLibrary.Orientation.Landscape, autoRotate: false);
    }
}
