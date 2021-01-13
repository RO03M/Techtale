using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class GlobalLight : MonoBehaviour {

    public bool isPowered = false;
    public float minIntensity = 0.1f;
    public float maxIntensity = 1;
    public float intensity;

    private Light2D lightComp;

    private void Start() {
        lightComp = this.GetComponent<Light2D>();
        intensity = minIntensity;
    }

    private void Update() {
        isPowered = GlobalData.hasPower;
        if (isPowered) {
            ChangeIntensity(true);
            lightComp.intensity = intensity;
        } else {
            ChangeIntensity(false);
            lightComp.intensity = intensity;
        }
    }

    private void ChangeIntensity(bool decrease) {
        if (decrease) {
            intensity = Mathf.Lerp(intensity, maxIntensity, 0.1f);
        } else {
            intensity = Mathf.Lerp(intensity, minIntensity, 0.1f);
        }
    }

}
