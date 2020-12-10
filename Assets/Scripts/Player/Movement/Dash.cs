using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    public Rigidbody2D rb;
    public ParticleSystem dashParticles;
    public float dashSpeed = 25f;
    public float dashTime = .5f;
    
    private PlayerGhostTrail playerGhost;
    private float initialGravityScale;
    private AnimationController animationController;
    private bool dashValidator = true;

    private void Start() {
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
        playerGhost = this.GetComponent<PlayerGhostTrail>();
        animationController = this.GetComponent<AnimationController>();
        PlayerInfo.dashTime = dashTime;
        var main = dashParticles.main;
        main.duration = dashTime;

        initialGravityScale = rb.gravityScale;
    }

    private void FixedUpdate() {
        if (PlayerInfo.isGrounded && dashValidator) PlayerInfo.canDash = true;
    }

    public void CallDash(float xRaw, float yRaw) {
        if (xRaw == 0 && yRaw == 0) DashMove(PlayerInfo.facing, yRaw);
        else DashMove(xRaw, yRaw);
        PlayerChecks.GenerateParticle(dashParticles);
    }

    public void DashMove(float x, float y) {
        Vector2 dashVector = new Vector2(x, y).normalized * dashSpeed;
        animationController.ChangeVariable("NormalVX", Mathf.Abs(x));//x has an absolute value because no matter which is the direction, only 
        animationController.ChangeVariable("NormalVY", y);
        rb.velocity = Vector2.zero;
        rb.velocity += dashVector;
        StartCoroutine(DashCourse(dashTime));
        playerGhost.CallGhost();
    }

    public IEnumerator DashCourse(float time = .2f) {
        PlayerInfo.canMove = false;
        PlayerInfo.canDash = false;
        dashValidator = false;
        PlayerInfo.isDashing = true;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(time - time / 10);
        PlayerInfo.canMove = true;

        yield return new WaitForSeconds(time);
    
        PlayerInfo.isDashing = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = initialGravityScale;
        yield return new WaitForSeconds(0.15f);
        dashValidator = true;
    }
}
