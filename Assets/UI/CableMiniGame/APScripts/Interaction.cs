using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script is used to interact with the cable panels objects
public class Interaction : MonoBehaviour {
    
    public EnableSystem enableSystem;
    public KeyCode interactKey;
    public Sprite interactKeySprite;
    public UnityEvent onCorrectMethod;
    public UnityEvent onWrongMethod;
    public bool triggered;

    private bool isCorrect;
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
        isCorrect = enableSystem.GetState();
        if (isCorrect && onCorrectMethod != null) onCorrectMethod.Invoke();
        else if (!isCorrect && onWrongMethod != null) onWrongMethod.Invoke();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
            triggered = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
            triggered = false;
    }

}
