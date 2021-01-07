using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour {

    public UnityEvent enterMethod, exitMethod;
    public string collisionTag = "Player";

    private Collider2D m_Collider;

    private void Start() {
        m_Collider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == collisionTag) {
            enterMethod.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == collisionTag) {
            exitMethod.Invoke();
        }
    }

}
