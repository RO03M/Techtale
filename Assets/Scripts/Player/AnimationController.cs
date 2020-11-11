using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    void Start() {
        if (rb == null) this.GetComponent<Rigidbody2D>();
        if (spriteRenderer == null) spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update() {
        VariablesUpdate();
        WalkAnim();
        if (PlayerInfo.isJumping && !PlayerInfo.isFalling) AnimPlay("Jump");
        if (PlayerInfo.isFalling) AnimPlay("Falling");
        if (PlayerInfo.isGrounded) AnimPlay("NormalMove");
    }

    void WalkAnim() {
        float inputX = Input.GetAxisRaw("Horizontal");
        bool isColliding = PlayerChecks.WallCollision(PlayerInfo.colliderCenter, PlayerInfo.colliderExtents, inputX);
        bool needFlip;
        PlayerInfo.facing = (int)inputX;
        animator.SetFloat("Speed", Mathf.Abs(inputX));
        if (isColliding) animator.SetFloat("Speed", 0);
        needFlip = PlayerInfo.facing == 1 ? false : true;
        spriteRenderer.flipX = needFlip;
    }

    public void AnimPlay(string anim) {
        animator.Play(anim);
    }

    public void VariablesUpdate() {
        animator.SetBool("Grounded", PlayerInfo.isGrounded);
        animator.SetBool("Falling", PlayerInfo.isFalling);
    }
}
