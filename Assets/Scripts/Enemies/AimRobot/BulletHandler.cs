using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour {
    
    public float destroyTime;
    public GameObject hitParticles;
    public GameObject parentObject;

    private float hitParticlesTimeDuration;

    private string[] ignoreTags = new string[] {
        "Router",
        "TriggerIgnore"
    };

    private void Start() {
        hitParticlesTimeDuration = hitParticles.GetComponent<ParticleSystem>().duration + 0.7f;
        StartCoroutine(DestroyBullet(destroyTime));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DestroyBullet(other);
    }

    private void DestroyBullet(Collider2D other) {
        for (int i = 0; i < ignoreTags.Length; i++) {
            if (other.gameObject.tag == ignoreTags[i]) return;
        }
        if (other.gameObject == parentObject) return;
        GameObject particlesClone = Instantiate(hitParticles, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(particlesClone, hitParticlesTimeDuration);
    }

    private IEnumerator DestroyBullet(float destroyTime) {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
        GameObject particlesClone = Instantiate(hitParticles, this.transform.position, Quaternion.identity);
        Destroy(particlesClone, hitParticlesTimeDuration);
    }

}
