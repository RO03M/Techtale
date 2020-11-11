using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostTrail : MonoBehaviour {
    
    public SpriteRenderer playerSpriteRenderer;
    public GameObject ghostPrefab;
    public Color ghostColor;
    public int ghostQuantity = 4;
    public float timeToDie = 2f;

    private float dashTime;

    private void Start() {
        if (playerSpriteRenderer == null) playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        dashTime = PlayerInfo.dashTime;
    }

    public void CallGhost() {
        if (ghostPrefab != null)
            StartCoroutine(CreateGhost(dashTime, ghostQuantity));
    }

    public IEnumerator CreateGhost(float time, int quantity) {
        for (int i = 0; i < quantity; i++) {
            yield return new WaitForSeconds(time / quantity);
            GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);
            SpriteRenderer ghostSpriteRenderer = ghost.GetComponent<SpriteRenderer>();
            ghostSpriteRenderer.sprite = playerSpriteRenderer.sprite;
            ghostSpriteRenderer.color = ghostColor;
            ghostSpriteRenderer.flipX = PlayerInfo.facingBool;
            StartCoroutine(GhostFadeOut(ghostSpriteRenderer, ghost, timeToDie - (timeToDie / 10)));
        }
        
    }

    public IEnumerator GhostFadeOut(SpriteRenderer renderer, GameObject ghost, float time = 1) {
        Color newColor = renderer.color;
        for (float i = 1; i > 0; i -= Time.deltaTime / time) {
            yield return new WaitForSeconds((Time.deltaTime / time));
            newColor.a = i;
            renderer.color = newColor;
        }
        Destroy(ghost);
    }

}
