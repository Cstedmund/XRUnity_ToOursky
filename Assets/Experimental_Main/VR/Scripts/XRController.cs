using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Management;
using Google.XR.Cardboard;

public class XRController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameobjList;
    [SerializeField]
    private Camera mainCamera;

    RuntimeXRLoaderManager m_runtimeXRLoaderManager;
    // Start is called before the first frame update
    private void Awake() {
        //set Renderer for VR according to android or ios
        if (FunctionLibrary.GetCurrentDevice() == FunctionLibrary.CurrentDevice.Android) {
            Debug.Log("android");
            mainCamera.GetComponent<UniversalAdditionalCameraData>().SetRenderer(1);
        } else {
            Debug.Log("ios");
            mainCamera.GetComponent<UniversalAdditionalCameraData>().SetRenderer(0);
        }
        m_runtimeXRLoaderManager = GetComponent<RuntimeXRLoaderManager>();
        m_runtimeXRLoaderManager.StartXR(1);
    }
    public void Start() {
        foreach(GameObject obj in gameobjList) {
            obj.SetActive(true);
        }
    }
}
