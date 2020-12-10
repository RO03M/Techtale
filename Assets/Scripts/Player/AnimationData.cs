using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationData {
    
    public static bool CanJump() {
        if (PlayerInfo.isJumping && !PlayerInfo.isFalling && !PlayerInfo.isUsingDHCPower && !PlayerInfo.isDashing) return true;
        return false;
    }

    public static bool CanMove() {
        if (PlayerInfo.isGrounded && !PlayerInfo.isUsingDHCPower && !PlayerInfo.isDashing) return true;
        return false;
    }

}
