using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : MonoBehaviour {

    public Sprite onSprite;
    public Sprite offSprite;

    private bool isOn = false;
    private Camera m_Camera;
    private SpriteRenderer spriteRenderer;
    private CameraShake shake;

    private void Start() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        m_Camera = Camera.main;
        shake = m_Camera.GetComponent<CameraShake>();
    }

    public void SwitchTurn() {
        isOn = !isOn;
        shake.canShake = true;
        if (isOn) spriteRenderer.sprite = onSprite;
        else spriteRenderer.sprite = offSprite;
    }

}
