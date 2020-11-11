using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script is used to interact with the cable panels objects
public class Interaction : MonoBehaviour {
    
    public bool triggered;
    public KeyCode interactKey;
    public EnableSystem enableSystem;

    public Sprite interactKeySprite;
    private GameObject spriteHandler;

    private void Start() {
        spriteHandler = this.transform.Find("SpriteHandler").gameObject;
        spriteHandler.GetComponent<SpriteRenderer>().sprite = interactKeySprite;
    }

    private void Update() {
        if (triggered) {
            if (Input.GetKeyDown(interactKey)) {
                enableSystem.ShowPanel();
            }
        }
        spriteHandler.SetActive(triggered);
    }

    private void OnTriggerStay2D(Collider2D other) {
        triggered = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        triggered = false;
    }

}
