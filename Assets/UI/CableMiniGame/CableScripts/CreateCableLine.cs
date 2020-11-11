using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script is attached on each cable base gameObject
// provides a feedback for the user when clicking in the cable base, then creating a LineRenderer for the mini-game
public class CreateCableLine : MonoBehaviour {
    
    public float cableWidth = 0.1f;
    public int cableBaseID;
    private Button cableButton;
    private Navigation navigation = new Navigation();
    private Material cableMaterial;

    private void Start() {
        cableButton = this.GetComponent<Button>();
        this.navigation.mode = Navigation.Mode.None;
        cableButton.navigation = this.navigation;
        cableButton.onClick.AddListener(ButtonTrigger);
    }

    private void ButtonTrigger() {
        if (transform.childCount == 0) CreateLineRenderer();
    }

    public void SetMaterial(Material cableMaterial) {
        this.cableMaterial = cableMaterial;
    }

    private void CreateLineRenderer() {
        GameObject cableLineObj = new GameObject("Cable Line");
        CableLineController controller = cableLineObj.AddComponent<CableLineController>();
        controller.cableID = cableBaseID;
        LineRenderer cableLine = cableLineObj.AddComponent<LineRenderer>();
        cableLineObj.transform.SetParent(this.transform);
        cableLine.SetPosition(0, this.transform.position);
        LineGraphics(cableLine);
    }

    private void LineGraphics(LineRenderer line) {
        line.SetWidth(cableWidth, cableWidth);
        line.alignment = LineAlignment.TransformZ;
        line.material = cableMaterial;
        line.sortingLayerName = "UI";
        line.useWorldSpace = false;
    }

}
