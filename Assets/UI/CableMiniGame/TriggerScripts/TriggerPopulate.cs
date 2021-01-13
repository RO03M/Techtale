using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPopulate : MonoBehaviour {
    
    public Sprite triggerSprite;
    public int routerID;

    private Vector2 colliderSize;

    private void Start() {
        colliderSize = this.GetComponent<GridLayoutGroup>().cellSize;
        Populate();
    }

    private void Populate() {
        for (int i = 0; i < 8; i++) {
            GameObject triggerObj = new GameObject("Cable Trigger " + (i + 1));
            triggerObj.transform.SetParent(this.transform);
            triggerObj.transform.localScale = Vector3.one;
            triggerObj.tag = "CableTrigger";
            triggerObj.layer = LayerMask.NameToLayer("UI");

            TriggerController controller = triggerObj.AddComponent<TriggerController>();
            controller.triggerID = i;

            Image triggerImage = triggerObj.AddComponent<Image>();
            triggerImage.sprite = triggerSprite;
            
            BoxCollider2D triggerCollider = triggerObj.AddComponent<BoxCollider2D>();
            triggerCollider.size = colliderSize;
            triggerCollider.isTrigger = true;
        }
    }

}
