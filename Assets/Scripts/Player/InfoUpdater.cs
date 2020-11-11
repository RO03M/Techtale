﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUpdater : MonoBehaviour {
    
    public Collider2D collider;
    public Rigidbody2D rb;

    private void Awake() {
        if (collider == null) collider = this.GetComponent<Collider2D>();
        if (rb == null) rb = this.GetComponent<Rigidbody2D>();
        PlayerInfo.colliderCenter = collider.bounds.center;
        PlayerInfo.colliderExtents = collider.bounds.extents;
    }

    private void Update() {
        PlayerInfo.colliderCenter = collider.bounds.center;
        GroundedUpdate();
        if (PlayerInfo.isGrounded) PlayerInfo.isJumping = false;
        if (rb.velocity.y < 0) PlayerInfo.isFalling = true;
        else PlayerInfo.isFalling = false;
    }

    private void GroundedUpdate() {
        if (rb.velocity.y == 0) PlayerInfo.isGrounded = PlayerChecks.IsGrounded(PlayerInfo.colliderCenter, PlayerInfo.colliderExtents);
        else PlayerInfo.isGrounded = false;
    }

}
