using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLoop : MonoBehaviour {

    [Range(-180, 180)]
    public float degressFrequency;
    public float speedMultiplier = 1;

    private void Update() {
        this.transform.Rotate(0, 0, speedMultiplier * degressFrequency * Time.deltaTime, Space.Self);
    }

}
