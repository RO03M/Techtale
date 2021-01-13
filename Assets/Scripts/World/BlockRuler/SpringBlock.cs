using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBlock : MonoBehaviour {

    private GameObject m_Object;

    public SpringBlock(GameObject m_Object) {
        this.m_Object = m_Object;
        SpringSetup();
    }

    private void SpringSetup() {
        Collider2D collider = m_Object.AddComponent<BoxCollider2D>();
        m_Object.AddComponent<SpringBlock>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.gameObject.tag != "Player") return;
        float normalY = other.contacts[0].normal.y;
        if (normalY == -1) {
            Rigidbody2D rb = other.transform.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }
    }

}
