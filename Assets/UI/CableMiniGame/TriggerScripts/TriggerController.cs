using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is attached at each trigger of the rj45
//it controlls the variables of the triggers, saying if he is occupied and his id
public class TriggerController : MonoBehaviour {
    
    public int? attachmentID;
    public int triggerID;
    public bool hasCableAttached = false;
    public GameObject cableObj;

    private void OnMouseDown() {
        RemoveAttachment();
    }

    public void RemoveAttachment() {
        Destroy(cableObj);
        hasCableAttached = false;
        attachmentID = null;
        UpdateTriggerData();
    }

    public void UpdateTriggerData() {
        this.transform.parent.parent.parent.GetComponent<TriggersData>().cablesOrder[triggerID] = attachmentID;
    }

}
