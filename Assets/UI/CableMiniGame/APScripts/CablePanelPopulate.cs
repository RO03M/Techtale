using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script does create a Cable Panel object based on each AP(Router), so we don't need to keep creating cable panels, just put it there
//It's important that we give to both, cable panels and APs, an ID \o/
public class CablePanelPopulate : MonoBehaviour {
    
    public GameObject cablePanelPrefab;
    public int routerID;//based on routers order
    private GameObject canvas;

    private void Start() {
        canvas = GameObject.Find("/Canvas");
        routerID = transform.GetSiblingIndex();
        GenerateCablePanel();
    }

    private void GenerateCablePanel() {
        GameObject cablePanelClone = Instantiate(cablePanelPrefab);
        cablePanelClone.transform.SetParent(canvas.transform);
        cablePanelClone.transform.localScale = Vector3.one;
        PrefabAssignment(cablePanelClone);
    }

    private void PrefabAssignment(GameObject cablePanelClone) {//this function just attach the clone prefab to all the variables from routers components
        this.GetComponent<ConnectionBehavior>().cablePanel = cablePanelClone;

        EnableSystem enableSystemClone = cablePanelClone.GetComponent<EnableSystem>();
        GameObject interactionObject = this.transform.Find("InteractionTrigger").gameObject;
        interactionObject.GetComponent<Interaction>().enableSystem = enableSystemClone;
    }

}
