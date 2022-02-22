using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPractise : MonoBehaviour
{
    [SerializeField]
    private GameObject btn, img;

    private RectTransform tempTrans;
    // Start is called before the first frame update
    void Start()
    {
        tempTrans = btn.GetComponent<RectTransform>();
        Debug.Log("anchorMin.x:" + tempTrans.anchorMin.x);
        Debug.Log("anchorMin.y:" + tempTrans.anchorMin.y);
        Debug.Log("anchorMax.x:" + tempTrans.anchorMax.x);
        Debug.Log("anchorMax.y:" + tempTrans.anchorMax.y);

        tempTrans = img.GetComponent<RectTransform>();
        Debug.Log("anchorMin.x:" + tempTrans.anchorMin.x);
        Debug.Log("anchorMin.y:" + tempTrans.anchorMin.y);
        Debug.Log("anchorMax.x:" + tempTrans.anchorMax.x);
        Debug.Log("anchorMax.y:" + tempTrans.anchorMax.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
