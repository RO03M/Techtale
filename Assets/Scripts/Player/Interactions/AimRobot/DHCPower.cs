using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHCPower : MonoBehaviour {

    public float radius = 10;
    public GameObject rippleEffect;
    public float rippleTime = 2;
    [Tooltip("Amount of times that the ripple effect will grow")]
    public float rippleSmoothness = 100;

    private int aimRobotCount = 0;
    private bool canCallEffect = false;
    private int callEffectCount = 0;
    private float effectTime;
    private int maxAimRobotDetection = 3;

    private void Start() {
        effectTime = rippleTime / rippleSmoothness;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            AimRobotDetection();
            canCallEffect = true;
        }

        if (canCallEffect && callEffectCount == 0) {
            StartCoroutine(RippleIncrease());
            callEffectCount++;
        }
    }

    private void AimRobotDetection() {
        Collider2D[] arrayObjects = Physics2D.OverlapCircleAll(this.transform.position, radius);
        List<GameObject> aimRobots = GetNearAimRobots(arrayObjects);
        for (int i = 0; i < aimRobots.Count; i++) {
            aimRobots[i].GetComponent<AimRobotBehaviour>().isPlayable = true;
        }
    }

    private List<GameObject> GetNearAimRobots(Collider2D[] arrayObjects) {
        List<Collider2D> aimRobotArray = new List<Collider2D>();
        List<GameObject> nearestAimRobots = new List<GameObject>();
        for (int i = 0; i < arrayObjects.Length; i++) {
            if (arrayObjects[i].gameObject.tag == "AimRobot") {
                aimRobotArray.Add(arrayObjects[i]);
            }
        }
        for (int i = 0; i < aimRobotArray.Count; i++) {
            if (nearestAimRobots.Count < maxAimRobotDetection)
                nearestAimRobots.Add(aimRobotArray[i].gameObject);
            else {
                for (int j = 0; j < nearestAimRobots.Count; j++) {
                    float currentAimRobotDistance = Vector3.Distance(transform.position, aimRobotArray[i].gameObject.transform.position);
                    float insiderArrayRobotDistance = Vector3.Distance(transform.position, nearestAimRobots[j].transform.position);
                    if (currentAimRobotDistance < insiderArrayRobotDistance) nearestAimRobots[j] = aimRobotArray[i].gameObject;
                }
            }
        }
        return nearestAimRobots;
    }

    private IEnumerator RippleIncrease() {
        float scaleIncreaseFactor = (radius * 2) / rippleSmoothness;
        if (canCallEffect) rippleEffect.transform.localScale += new Vector3(scaleIncreaseFactor, scaleIncreaseFactor, 0);
        float rippleEffectX = rippleEffect.transform.localScale.x;
        float rippleEffectY = rippleEffect.transform.localScale.y;
        if (rippleEffectX >= radius * 2 && rippleEffectY >= radius * 2) {
            canCallEffect = false;
            callEffectCount = 0;
            rippleEffect.transform.localScale = Vector3.zero;
            yield break;
        }
        yield return new WaitForSeconds(effectTime);
        StartCoroutine(RippleIncrease());
    }

}
