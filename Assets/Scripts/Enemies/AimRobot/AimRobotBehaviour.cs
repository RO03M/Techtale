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
    public GameObject[] particlesObj;

    private SpriteRenderer spriteRenderer;
    private int coroutineController = 0;
    private GameObject player;

    private void Start() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    private void Update() {
        if (isPlayable && coroutineController == 0) {
            spriteRenderer.sprite = playableSprite;
            StartCoroutine(BackTransition());
            coroutineController++;
        }
    }

    private IEnumerator BackTransition() {
        int index = player.GetComponent<DHCPower>().aimRobots.IndexOf(this.gameObject);
        yield return new WaitForSeconds(timeToBack);
        isPlayable = false;
        player.GetComponent<DHCPower>().aimRobotCount--;
        player.GetComponent<DHCPower>().aimRobots.Remove(this.gameObject);
        coroutineController = 0;
        spriteRenderer.sprite = defaultSprite;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "AimRobotBullet(Clone)") {
            if (other.gameObject.GetComponent<BulletHandler>().parentObject != this.gameObject) {
                DestroyAimRobot();
            }
        }
    }

    public void DestroyAimRobot() {
        Destroy(this.gameObject);
        DestroyEffects();
    }

    private void DestroyEffects() {
        for (int i = 0; i < particlesObj.Length; i++) {
            GameObject particleClone = Instantiate(particlesObj[i], this.transform.position, Quaternion.identity);
            ParticleSystem particleSystem = particleClone.GetComponent<ParticleSystem>();
            float timeToDestroy = particleSystem.duration * particleSystem.startLifetime;
            Destroy(particleClone, timeToDestroy);
        }
    }

}
