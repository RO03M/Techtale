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

    private void Start() {
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
        playerGhost = this.GetComponent<PlayerGhostTrail>();
        PlayerInfo.dashTime = dashTime;
        var main = dashParticles.main;
        main.duration = dashTime;

        initialGravityScale = rb.gravityScale;
    }

    private void FixedUpdate() {
        if (PlayerInfo.isGrounded) PlayerInfo.canDash = true;
    }

    public void CallDash(float xRaw, float yRaw) {
        if (xRaw == 0 && yRaw == 0) DashMove(PlayerInfo.facing, yRaw);
        else DashMove(xRaw, yRaw);
        PlayerChecks.GenerateParticle(dashParticles);
    }

    public void DashMove(float x, float y) {
        Vector2 dashVector = new Vector2(x, y).normalized * dashSpeed;
        rb.velocity = Vector2.zero;
        rb.velocity += dashVector;
        StartCoroutine(DashCourse(dashTime));
        playerGhost.CallGhost();
    }

    public IEnumerator DashCourse(float time = .2f) {
        PlayerInfo.canMove = false;
        rb.gravityScale = 0;
        PlayerInfo.isDashing = true;
        PlayerInfo.canDash = false;

        yield return new WaitForSeconds(time - time / 10);
        PlayerInfo.canMove = true;

        yield return new WaitForSeconds(time);
    
        PlayerInfo.isDashing = false;
        rb.velocity = Vector2.zero;
        rb.gravityScale = initialGravityScale;
    }
}
