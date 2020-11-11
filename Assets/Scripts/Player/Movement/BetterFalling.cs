using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterFalling : MonoBehaviour {

    public Rigidbody2D rb;
    public float minVelocity = -2;
    public float velocityDecreaseFactor = -.5f;

    void Start() {
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        BetterFall();
    }

    void BetterFall() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        }
    }
}
