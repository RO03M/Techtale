using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public bool canShake = false;
    public float shakeDuration = 1;
    public float shakeIntensity = 0.5f;
    public Transform playerTransform;

    private void Update() {
        if (canShake) {
            StartCoroutine(Shake());
            StartCoroutine(StopShaking());
        }
    }

    public IEnumerator Shake() {
        float randomNumber = Random.Range(0, 360);
        Vector3 originalPosition = this.transform.position;
        Vector3 shakePosition = new Vector3(playerTransform.position.x, playerTransform.position.y, -10) + new Vector3(Mathf.Cos(randomNumber), Mathf.Sin(randomNumber), 0) * shakeIntensity;
        this.transform.position = shakePosition;
        yield return new WaitForSeconds(0.05f);
    }

    IEnumerator StopShaking() {
        yield return new WaitForSeconds(shakeDuration);
        canShake = false;
    }

}
