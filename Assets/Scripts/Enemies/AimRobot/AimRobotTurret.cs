using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRobotTurret : MonoBehaviour {

    public GameObject aimRobotBullet;
    public float bulletSpeed = 5;
    public float cloneDestroyTime = 5;
    public float fireDelay;
    public float minDistance;

    protected bool canFire = true;
    protected bool isPlayable;

    private AimRobotBehaviour aimRobotBehaviour;
    private float zAngle;

    private void Start() {
        aimRobotBehaviour = gameObject.GetComponentInParent<AimRobotBehaviour>();
        minDistance = aimRobotBehaviour.minDistance;
        fireDelay = aimRobotBehaviour.fireDelay;
    }

    private void Update() {
        this.isPlayable = aimRobotBehaviour.isPlayable;
        if (isPlayable) {
            LookAt();
            if (Input.GetMouseButtonDown(0) && canFire) Fire();
        } else DefaultBehaviour();
    }

    private void DefaultBehaviour() {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        float currentDistance = Vector3.Distance(transform.position, playerPosition);
        if (currentDistance <= minDistance) {
            LookAt(playerPosition);
            Fire();
        }
    }

    private void LookAt() {
        Vector3 thisPosition = this.transform.position;
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 positionInRadius = Vector3.zero;
        positionInRadius.x = targetPosition.x - thisPosition.x;
        positionInRadius.y = targetPosition.y - thisPosition.y;
        zAngle = Mathf.Atan2(positionInRadius.x, positionInRadius.y) * -Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zAngle));
    }

    private void LookAt(Vector3 lookTarget) {
        Vector3 thisPosition = this.transform.position;
        Vector3 targetPosition = lookTarget;
        Vector3 positionInRadius = Vector3.zero;
        positionInRadius.x = targetPosition.x - thisPosition.x;
        positionInRadius.y = targetPosition.y - thisPosition.y;
        zAngle = Mathf.Atan2(positionInRadius.x, positionInRadius.y) * -Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, zAngle));
    }

    private void Fire() {
        if (!canFire) return;
        Quaternion quaternionAngle = Quaternion.Euler(new Vector3(0, 0, zAngle));
        float angle = quaternionAngle.eulerAngles.z;
        angle *= Mathf.Deg2Rad;
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);
        GameObject bulletClone = Instantiate(aimRobotBullet, transform.position, quaternionAngle);
        Rigidbody2D cloneRb = bulletClone.GetComponent<Rigidbody2D>();
        cloneRb.velocity = new Vector2(cos * bulletSpeed, sin * bulletSpeed);
        StartCoroutine(FireDelay());
        Destroy(cloneRb, cloneDestroyTime);
    }

    private IEnumerator FireDelay() {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

}
