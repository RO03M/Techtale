using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour {

    private Camera m_Camera;
    private GameObject m_Player;

    private void Start() {
        m_Camera = Camera.main;
        m_Player = GameObject.Find("Player");
    }

    private void OnDestroy() {
        BackFromTheDeads();
    }

    private void BackFromTheDeads() {
        m_Camera.GetComponent<CameraLockMovement>().canFollow = true;
        m_Player.transform.position = Vector2.zero;
        m_Player.GetComponent<SpriteRenderer>().enabled = true;
        m_Player.GetComponent<Rigidbody2D>().gravityScale = 3;
        PlayerInfo.canMove = true;
        PlayerInfo.canJump = true;
    }

}
