using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour {

    private Animator animator;

    public void OpenDoor() {
        animator = this.GetComponent<Animator>();
        animator.Play("Opened");
    }
    
}
