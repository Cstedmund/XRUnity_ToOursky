using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image6Interaction : MonoBehaviour
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
        normalMaterial = modelContainer.GetChild(1).gameObject.GetComponent<MeshRenderer>().materials;
    }
    private void FixedUpdate() {
        if(lightening) {
            brightLevel++;
            if(brightLevel == 100) {
            }
        }
    }
    public void Lightening(bool lighteningToggle) {
        this.lightening = lighteningToggle;
        if(lightening) {
            foreach(Transform child in modelContainer) {
                if(child.gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer)) {
                    meshRenderer.materials = hightlightMaterial;
                }
                //child.gameObject.GetComponent<MeshRenderer>().materials = hightlightMaterial;
            }
        }
        if(!lightening) {
            foreach(Transform child in modelContainer) {
                if(child.gameObject.TryGetComponent<MeshRenderer>(out var meshRenderer)) {
                    meshRenderer.materials = normalMaterial;
                }
                //child.gameObject.GetComponent<MeshRenderer>().materials = normalMaterial;
            }
        }
    }
}
