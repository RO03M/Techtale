using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeTeleport : MonoBehaviour {

    private GameObject m_Player;

    private void Start() {
        m_Player = GameObject.Find("Player");
        if (this.transform.lossyScale.x < 0) this.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void Teleport(GameObject targetObj) {
        Vector3 tpPosition = targetObj.transform.position;
        SpriteRenderer targetSpriteRenderer = targetObj.GetComponent<SpriteRenderer>();
        if (targetSpriteRenderer.transform.localScale.x == 1) PlayerInfo.facing = 1;
        else PlayerInfo.facing = -1;
        m_Player.transform.position = tpPosition;
        m_Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

}
