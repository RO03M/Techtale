using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    public float speed = 1f;
    public Rigidbody2D rb;
    public Animator animator;
    public ParticleSystem dust;
    public SpriteRenderer spriteRenderer;

    float direction = 1;
    float currentVelocity;
    float lastVelocity;
    float maxVelocityDifference;

    private Dash dash;

    void Start() {
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
        if (spriteRenderer == null) spriteRenderer = this.GetComponent<SpriteRenderer>();
        dash = this.GetComponent<Dash>();
        maxVelocityDifference = speed * 2;
    }

    void Update() {
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Movement(xRaw);
        if (Input.GetKeyDown(KeyCode.M) && PlayerInfo.canDash) dash.CallDash(xRaw, yRaw);
    }

    private void FixedUpdate() {
        DustSpawner();
    }

    void Movement(float inputX) {
        Vector2 movement = new Vector2(inputX * speed, rb.velocity.y);
        if (PlayerInfo.isDashing) movement *= Vector2.right;
        if (PlayerInfo.canMove) rb.velocity = movement;
    }

    void DustSpawner() {
        //This function calls all the other functions to generate dust
        if (Random.Range(0, 1000) >= 900 && rb.velocity.x != 0 && PlayerInfo.isGrounded) PlayerChecks.GenerateParticle(dust);
        SpeedBackDust();
    }

    void SpeedBackDust() {
        currentVelocity = rb.velocity.x;
        float difference = currentVelocity - lastVelocity;

        if ((difference == -maxVelocityDifference || difference == maxVelocityDifference) && PlayerInfo.isGrounded) {
            PlayerChecks.GenerateParticle(dust);
        }
        lastVelocity = currentVelocity;
    }

}
