using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public static bool isPaused = false;

    private static Canvas canvasComp;

    private void Start() {
        canvasComp = this.GetComponent<Canvas>();
        canvasComp.enabled = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) ToggleGameState();
    }

    private void ToggleGameState() {
        if (isPaused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame() {
        isPaused = true;
        Time.timeScale = 0;
        canvasComp.enabled = isPaused;
    }

    public static void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1;
        canvasComp.enabled = isPaused;
    }

}
