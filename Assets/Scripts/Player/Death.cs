using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public GameObject deathPrefab;
    public float timeToRevive = 3;

    private Camera m_Camera;

    private void Start() {
        m_Camera = Camera.main;
    }

    public void DeathCaller() {
        GameObject death = Instantiate(deathPrefab, this.transform.position, Quaternion.identity);
        Destroy(death, timeToRevive);//the time to destroy the death prefab is the time to revive because the character is going to be set active again after the OnDestroy method from death prefab be called
        DisablePlayer();    
    }

    public void DisablePlayer() {
        m_Camera.GetComponent<CameraLockMovement>().canFollow = false;
        m_Camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PlayerInfo.canMove = false;
        PlayerInfo.canJump = false;
    }

}
