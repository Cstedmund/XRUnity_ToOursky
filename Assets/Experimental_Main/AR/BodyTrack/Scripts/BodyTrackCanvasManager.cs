using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BodyTrackCanvasManager : MonoBehaviour
{
    private EthnicDatabase ethnicDatabase;
    private HumanBodyTracker humanBodyTracker;

    [Header("Canvas")]
    [SerializeField]
    private Transform selectPanelContent;
    [SerializeField]
    private GameObject clothButtonPrefab,currentOption;

    [SerializeField]
    private Slider[] silder;

    public List<Quaternion> initalBoneQuaternion = new List<Quaternion>();
    public bool firstTime = true;

    private void Start() {
        FunctionLibrary.SetDeviceOrientation(orientation: FunctionLibrary.Orientation.Portrait, autoRotate: false);
        ethnicDatabase = GameObject.Find("EthnicDatabase").GetComponent<EthnicDatabase>();
        humanBodyTracker = GameObject.Find("Human Body Tracking").GetComponent<HumanBodyTracker>();
        //for (var i = 0; i<10; i++) {
        //    EthnicModel ethnic = ethnicDatabase.GetAllEthnicGroups()[i];
        //    GameObject button = Instantiate(clothButtonPrefab, selectPanelContent);
        //    button.GetComponentInChildren<TextMeshProUGUI>().text = ethnic.EthnicGroup;
        //    button.GetComponent<Button>().onClick.AddListener(() => SelectCloth(ethnicDatabase.GetAllEthnicGroups().IndexOf(ethnic)));
        //}
        foreach (EthnicModel ethnic in ethnicDatabase.GetAllEthnicGroups()) {
            if (ethnic.ModelPrefab != null) {
                if ((ethnic.ModelPrefab.name != "FemaleClothes")&(ethnic.ModelPrefab.name != "FemaleLongDress")) {
                    //Debug.Log(ethnic.ModelPrefab.name);
                    GameObject button = Instantiate(clothButtonPrefab, selectPanelContent);
                    button.GetComponentInChildren<TextMeshProUGUI>().text = ethnic.EthnicGroup;
                    button.GetComponent<Button>().onClick.AddListener(() => SelectCloth(ethnicDatabase.GetAllEthnicGroups().IndexOf(ethnic)));
                }
            } else if (ethnic.ModelPrefab == null) {
                GameObject button = Instantiate(clothButtonPrefab, selectPanelContent);
                button.GetComponentInChildren<TextMeshProUGUI>().text = ethnic.EthnicGroup;
                button.GetComponent<Button>().onClick.AddListener(() => SelectCloth(ethnicDatabase.GetAllEthnicGroups().IndexOf(ethnic)));
            }
        }      
        SelectCloth(0);
    }

    public void SelectCloth(int index) {
        //get choosen object in list
        if (GameManager.Instance.debugOn)
            currentOption.GetComponent<TextMeshProUGUI>().text = ethnicDatabase.GetEthnicByIndex(index).EthnicGroup;
        EthnicModel chosenEthnic = ethnicDatabase.GetEthnicByIndex(index);
        ethnicDatabase.SelectedEthnicGroup = chosenEthnic;
        humanBodyTracker.ChangeModel();
    }

    public void UpdateInitalBoneQuaternion(Quaternion quaternion) {
        if (!firstTime) 
            return;
        initalBoneQuaternion.Add(quaternion);
    }

    public void ClicktoResetBoneRotation() {
        FindObjectOfType<BoneController>().ResetBoneRotation(initalBoneQuaternion);
    }

}
