using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlock : MonoBehaviour {

    private GameObject m_Object;
    public Collider2D m_Collider;

    public SpikeBlock(GameObject m_Object) {
        this.m_Object = m_Object;
        SpikeBehaviour();
    }

    private void SpikeBehaviour() {
        if (!(m_Collider = m_Object.GetComponent<Collider2D>())) m_Collider = m_Object.AddComponent<BoxCollider2D>();
        m_Collider.isTrigger = true;
        m_Object.AddComponent<SpikeBlock>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.gameObject.tag == "Player") {
            other.GetComponent<Death>().DeathCaller();
        }
    }

}
