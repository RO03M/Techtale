using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script has the Player's states at runtime of the game
public static class PlayerInfo {
    
    public static bool canDash = true;
    public static bool canJump = true;
    public static bool canMove = true;
    public static Vector2 colliderCenter;
    public static Vector2 colliderExtents;
    public static float dashTime;
    private static int direction = 1;//1 is default facing
    public static bool isDashing = false;
    public static bool isFalling = false;
    public static bool isGrounded;
    public static bool isJumping = false;
    public static bool isUsingDHCPower = false;
    public static float maxVerticalVelocity = 25;
    public static Vector2 velocity = Vector2.zero;

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
