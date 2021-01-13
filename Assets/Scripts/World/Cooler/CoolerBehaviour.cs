using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolerBehaviour : MonoBehaviour {

    public bool isPowered = false;
    public bool isCommonPower = true;//means that after power supply turns on it will turn on too

    private void Start() {
        CoolerSwitch();
    }

    private void Update() {
        if (isCommonPower) {
            if (GlobalData.hasPower) isPowered = true;
            CoolerSwitch();
        }
    }

    private void CoolerSwitch() {
        GameObject force = transform.GetChild(0).gameObject;
        force.SetActive(isPowered);
    }

    public void CoolerSwitch(bool power) {
        if (isCommonPower) return;
        GameObject force = transform.GetChild(0).gameObject;
        force.SetActive(power);
    }

}
