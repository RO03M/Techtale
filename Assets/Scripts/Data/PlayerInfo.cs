using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo {
    
    private static int direction = 1;//1 is default facing
    public static float dashTime;
    public static Vector2 velocity = Vector2.zero;
    public static Vector2 colliderCenter;
    public static Vector2 colliderExtents;
    public static bool isGrounded;
    public static bool canMove = true;
    public static bool isDashing = false;
    public static bool canDash = true;
    public static bool isJumping = false;
    public static bool isFalling = false;

    public static int facing {
        get {
            return direction;
        } set {
            if (value == 1 || value == -1)
                direction = value;
        }
    }

    public static bool facingBool {
        get {
            if (direction == 1) return false;//don't need to flipX
            else return true;//need to flipX
        }
    }

}
