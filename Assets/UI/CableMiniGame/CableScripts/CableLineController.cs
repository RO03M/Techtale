using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached at each of the LineRenderers created in the cable base object
// Here is where the functions to move the cable line, attach it to a trigger, change his position may be found
public class CableLineController : MonoBehaviour {

    private LineRenderer line;
    private Vector3 lineFinalPos;
    private Vector2 mousePosition;
    private bool mouseLock = true;
    private bool attached = false;
    private float getColliderWithMouseZone = .05f;
    public int cableID;

    private void Start() {
        line = this.GetComponent<LineRenderer>();
        line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Update() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseLock) lineFinalPos = mousePosition - new Vector2(this.transform.position.x, this.transform.position.y);
        line.SetPosition(1, lineFinalPos);
        if (Input.GetMouseButtonUp(0) && !attached) CableController();
    }

    private void CableController() {
        Collider2D infoHandler = GetColliders();
        if (infoHandler) {
            TriggerController controller = infoHandler.gameObject.GetComponent<TriggerController>();
            bool hasAttachment = controller.hasCableAttached;
            
            if (hasAttachment) controller.RemoveAttachment();
            mouseLock = false;
            attached = true;
            controller.cableObj = this.gameObject;
            controller.hasCableAttached = true;
            controller.attachmentID = cableID;
            controller.UpdateTriggerData();
            line.SetPosition(1, infoHandler.gameObject.transform.position);
        } else Destroy(this.gameObject);
    }

    private Collider2D GetColliders() {
        Vector2 pointA = mousePosition + Vector2.one * getColliderWithMouseZone;
        Vector2 pointB = mousePosition - Vector2.one * getColliderWithMouseZone;
        int layerMask = LayerMask.GetMask("UI");
        return Physics2D.OverlapArea(pointA, pointB, layerMask);
    }

}
