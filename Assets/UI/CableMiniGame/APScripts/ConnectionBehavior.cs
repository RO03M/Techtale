using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script has to be attached at each router object
//we are going to pass the Cable Panel reference, so we can check if the player has done everything right
public class ConnectionBehavior : MonoBehaviour {
    
    public GameObject cablePanel;
    
    private bool isCorrect = false;
    private GameObject greenLight;
    private GameObject redLight;

    private void Update() {
        isCorrect = cablePanel.GetComponent<TriggersData>().isCorrect;
        LightsBehavior();
    }

    private void LightsBehavior() {
        GameObject greenLight = this.transform.Find("GreenLight").gameObject;
        GameObject redLight = this.transform.Find("RedLight").gameObject;
        greenLight.SetActive(isCorrect);
        redLight.SetActive(!isCorrect);
    }

}
