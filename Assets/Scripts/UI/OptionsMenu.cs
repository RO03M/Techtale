using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {
    
    public GameObject backWindow;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            if (backWindow == null) return;
            this.gameObject.SetActive(false);
            backWindow.SetActive(true);
        }
    }

}
