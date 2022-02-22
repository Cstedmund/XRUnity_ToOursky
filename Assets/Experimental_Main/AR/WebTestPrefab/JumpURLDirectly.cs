using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpURLDirectly : MonoBehaviour
{
    [SerializeField]
    private Transform modelContainer;
    [SerializeField]
    private Material[] hightlightMaterial;

    private int brightLevel;
    private bool lightening;
    private Material[] normalMaterial;

    private void Start() {
        brightLevel = 0;
        normalMaterial = modelContainer.GetChild(0).gameObject.GetComponent<MeshRenderer>().materials;
    }
    private void FixedUpdate() {
        if (lightening) {
            brightLevel++;
            if (brightLevel == 100) {
            }
        }
    }
    public void Lightening(bool lighteningToggle) {
        this.lightening = lighteningToggle;
        if (lightening) {
            foreach (Transform child in modelContainer) {
                if (child.gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer)) {
                    meshRenderer.materials = hightlightMaterial;
                    return;
                }
            }
        }
        if (!lightening) {
            foreach (Transform child in modelContainer) {
                if (child.gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer)) {
                    meshRenderer.materials = normalMaterial;
                    return;
                }
            }
        }
    }

    public void GoURL() {
        Application.OpenURL("https://eresources.oupchina.com.hk/npcla3e/SBC/?grade=3&unit=16&ch=15#");
    }
}
