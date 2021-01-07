using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionDetection : MonoBehaviour {

    public KeyCode keyTrigger;
    public UnityEvent method;

    private SpriteRenderer spriteRenderer;
    private KeyMesh keyMesh;
    private Camera m_Camera;

    private void Start() {
        m_Camera = Camera.main;
        keyMesh = m_Camera.GetComponent<KeyMesh>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = keyMesh.GetKeySprite(keyTrigger);
        spriteRenderer.enabled = false;

        if (gameObject.GetComponent<BoxCollider2D>() == null) {
            Collider2D collider = gameObject.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Player") return;
        spriteRenderer.enabled = true;   
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag != "Player") return;
        if (Input.GetKeyDown(keyTrigger)) {
            method.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag != "Player") return;
        spriteRenderer.enabled = false;
    }

}
