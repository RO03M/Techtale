using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRobotBehaviour : MonoBehaviour {
    
    public enum AimRobotLockOptions { EAST = 0, NORTHEAST = 45, NORTH = 90, NORTHWEST = 135, WEST = 180, SOUTHWEST = 225, SOUTH = 270, SOUTHEAST = 315};
    public Sprite playableSprite;
    public Sprite defaultSprite;
    public float fireDelay = 1;
    public bool isPlayable = false;
    public bool locked = false;
    public AimRobotLockOptions lockOptionsDegress;
    public float minDistance = 10;
    public int timeToBack = 10;

    private SpriteRenderer spriteRenderer;
    private int coroutineController = 0;

    private void Start() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (isPlayable && coroutineController == 0) {
            spriteRenderer.sprite = playableSprite;
            StartCoroutine(BackTransition());
            coroutineController++;
        }
    }

    private IEnumerator BackTransition() {
        yield return new WaitForSeconds(timeToBack);
        isPlayable = false;
        coroutineController = 0;
        spriteRenderer.sprite = defaultSprite;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "AimRobotBullet(Clone)") {
            if (other.gameObject.GetComponent<BulletHandler>().parentObject != this.gameObject)
                Destroy(this.gameObject);
        }
    }

}
