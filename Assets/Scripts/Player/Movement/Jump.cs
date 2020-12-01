using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float jumpForce = 1;
    public float minJumpTime = .2f;
    public Rigidbody2D rb;
    public ParticleSystem particles;

    float jumpTime;

    void Start() {
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
        jumpTime = minJumpTime;
    }

    void Update() {
        jumpTime += Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) jumpTime = 0;

        if (jumpTime <= minJumpTime && PlayerInfo.isGrounded && PlayerInfo.canJump) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTime = minJumpTime;
            PlayerChecks.GenerateParticle(particles);
            PlayerInfo.isJumping = true;
        }
    }

}
