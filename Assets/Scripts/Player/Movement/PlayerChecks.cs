using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecks {

    public static bool IsGrounded(Vector2 center, Vector2 extent) {
        Vector2 pointA = center - (Vector2.right * (extent.x - .1f)) - (Vector2.up * extent.y);
        Vector2 pointB = center + (Vector2.right * (extent.x - .1f)) - (Vector2.up * (extent.y + .01f));
        return Physics2D.OverlapArea(pointA, pointB);
    }

    public static bool WallCollision(Vector2 center, Vector2 extent, float inputX, bool normalized = true) {
        float direction;
        if (!normalized) direction = CheckPolar(inputX);
        else direction = inputX;
        Vector2 pointA = center + (direction * Vector2.right * (extent.x + .2f)) + (Vector2.up * (extent.y - .1f));
        Vector2 pointB = center + (direction * Vector2.right * (extent.x + 1f)) - (Vector2.up * (extent.y - .1f));

        Collider2D collider = Physics2D.OverlapArea(pointA, pointB);
        if (collider) {
            if (collider.isTrigger) return false;
            else PlayerInfo.isColliding = true;
            return true;
        }
        PlayerInfo.isColliding = false;
        return false;
    }

    public static int CheckPolar(float number) {
        if (number > 0) return 1;
        else if (number < 0) return -1;
        else return 0;
    }

    public static void GenerateParticle(ParticleSystem particles) {
        particles.Play();
    }

}
