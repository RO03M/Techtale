using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxTrigger : MonoBehaviour {
    
    public GameObject dialogBox;
    [TextArea(3, 10)]
    public string text;

    public Text dialogTextComponent;

    private void Start() {
        dialogTextComponent = dialogBox.transform.GetChild(0).GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "Player") return;
        dialogTextComponent.text = text;
        dialogBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag != "Player") return;
        dialogBox.SetActive(false);
    }

}
