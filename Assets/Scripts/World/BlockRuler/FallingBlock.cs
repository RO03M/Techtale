using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    private Collider2D collider;
    private GameObject m_Object;
    private bool goingToFall = false;

    public FallingBlock(GameObject m_Object) {
        this.m_Object = m_Object;
        FallingSetup();
    }

    private void FallingSetup() {
        collider = m_Object.AddComponent<BoxCollider2D>();
        m_Object.AddComponent<FallingBlock>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.transform.gameObject.CompareTag("Player") || goingToFall) return;
        float normalY = other.contacts[0].normal.y;
        if (normalY == -1) {
            goingToFall = true;
            StartCoroutine(FallingScript());
        }
    }

    private IEnumerator FallingScript() {
        yield return new WaitForSeconds(2.5f);
        Rigidbody2D rb = this.gameObject.AddComponent<Rigidbody2D>();
        this.GetComponent<Collider2D>().isTrigger = true;
    }

}
