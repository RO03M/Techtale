using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxTrigger : MonoBehaviour {
    
    public GameObject dialogBox;
    public GameObject nextGO;
    public GameObject backGO;
    public Text indexGO;
    [TextArea(3, 10)]
    public string[] text;
    public bool isActive = false;

    private Text dialogTextComponent;
    public int windowIndex;

    private void Start() {
        dialogTextComponent = dialogBox.transform.GetChild(0).GetComponent<Text>();
        windowIndex = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && isActive) {
            windowIndex++;
            if (windowIndex > text.Length - 1) {
                windowIndex = text.Length - 1;
            }
            dialogTextComponent.text = text[windowIndex];
        } else if (Input.GetKeyDown(KeyCode.Backspace) && isActive) {
            windowIndex--;
            if (windowIndex < 0) windowIndex = 0;
            dialogTextComponent.text = text[windowIndex];
        }

        indexGO.text = "" + (windowIndex + 1);

        if (windowIndex > 0 && windowIndex < text.Length - 1) {
            nextGO.SetActive(true);
            backGO.SetActive(true);
        } else if (windowIndex == 0) {
            nextGO.SetActive(true);
            backGO.SetActive(false);
        } else if (windowIndex == text.Length - 1) {
            nextGO.SetActive(false);
            backGO.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Player") return;
        dialogTextComponent.text = text[windowIndex];
        isActive = true;
        dialogBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag != "Player") return;
        isActive = false;
        Close();
    }

    private void Close() {
        dialogBox.SetActive(false);
    }

}
