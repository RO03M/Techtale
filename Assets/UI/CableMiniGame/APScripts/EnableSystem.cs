using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSystem : MonoBehaviour {
    
    public void ShowPanel() {
        this.gameObject.SetActive(true);
    }

    public bool GetState() {
        return this.GetComponent<TriggersData>().isCorrect;
    }

}
