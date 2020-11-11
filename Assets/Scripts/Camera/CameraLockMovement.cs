using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockMovement : MonoBehaviour {

    public Transform Player;
    public float maxYDistance = 3f;
    public float maxXDistance = 3f;
    [Range(0, 1)]
    public float transitionTime = .5f;

    Vector2 playerPosition;

    void Start() {
        if (Player == null) Player = GameObject.Find("Player").transform;
    }

    void Update() {
        playerPosition = Player.position;
        float yCamDistance = transform.position.y - playerPosition.y;
        float xCamDistance = transform.position.x - playerPosition.x;
        if ((yCamDistance > maxYDistance || yCamDistance < -maxYDistance) || (xCamDistance > maxXDistance || xCamDistance < -maxXDistance)) {
            transform.position = Vector3.Slerp(transform.position, new Vector3(playerPosition.x, playerPosition.y, -10), transitionTime);
        }
    }

    void CameraTransition(Vector3 target) {
        float yCamDistance = transform.position.y - target.y;
        float xCamDistance = transform.position.x - target.x;
        if ((yCamDistance > maxYDistance || yCamDistance < -maxYDistance)) {
            Vector3 destinyPos = new Vector3(transform.position.x, target.y, -10);
            transform.position = Vector3.Slerp(transform.position, destinyPos, transitionTime);
        }

        if ((xCamDistance > maxXDistance || xCamDistance < -maxXDistance)) {
            Vector3 destinyPos = new Vector3(target.x, transform.position.y, -10);
            transform.position = Vector3.Slerp(transform.position, destinyPos, transitionTime);
        }
    }
}
