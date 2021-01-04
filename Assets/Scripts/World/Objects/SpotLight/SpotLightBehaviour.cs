using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class SpotLightBehaviour : MonoBehaviour {

    public Color[] colorsArray;
    public GameObject m_Player;
    public Vector2 playerPosition;
    public float timeToChange = 1f;

    private float angle;
    private int colorIndex;
    private Light2D lightComp;

    private void Start() {
        m_Player = GameObject.Find("Player");
        playerPosition = m_Player.transform.position;
        lightComp = this.GetComponent<Light2D>();
        colorsArray = new Color[] {
            new Color(6, 82, 221),
            new Color(234, 32, 39),
            new Color(0, 148, 50),
            new Color(238, 90, 36)
        };
        StartCoroutine(ColorChange());
    }

    private void Update() {
        playerPosition = m_Player.transform.position;
        Vector2 angleToTarget = Vector2.zero;
        angleToTarget.x = playerPosition.x - this.transform.position.x;
        angleToTarget.y = playerPosition.y - this.transform.position.y;
        angle = Mathf.Atan2(angleToTarget.x, angleToTarget.y) * -Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private IEnumerator ColorChange() {
        lightComp.color = colorsArray[colorIndex];
        colorIndex++;
        if (colorIndex >= colorsArray.Length - 1) colorIndex = 0;
        yield return new WaitForSeconds(timeToChange);
        StartCoroutine(ColorChange());
    }

}
