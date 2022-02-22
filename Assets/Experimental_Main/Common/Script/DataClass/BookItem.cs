using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[CreateAssetMenu(fileName = "NewBook", menuName = "Custom Scriptable Object/CreateNewBook")]
[SerializeField]
public class BookItem : ScriptableObject {
    [SerializeField]
    public string bookID;
    [SerializeField]
    public string bookName;
    [SerializeField]
    public string bookNameCn;
    [SerializeField]
    public string sceneName;
    [SerializeField]
    public GameManager.Book bookEnum;
    [SerializeField]
    public string chapterNumber;
    //[SerializeField]
    //public Color bookColor;
    [SerializeField]
    public BookModeType[] mode;
    [SerializeField]
    public XRReferenceImageLibrary aRImageLibrary;

    public enum BookModeType {
        AR,
        VR,
        WebResources,
        ARBodyTrack
    }

}
