using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectables : MonoBehaviour {
    
    public Color unselectedColor;
    public Color selectedColor;
    public bool scrollable;

    public List<GameObject> texts = new List<GameObject>();
    public int wheelValue = 0;
    public int childCount;
    private Text textComp;
    private int textsSize;

    private void Start() {
        childCount = transform.childCount;
        for (int i = 0; i < childCount; i++) {
            if (transform.GetChild(i).gameObject.tag == "SelectableText") texts.Add(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < texts.Count; i++) {
            texts[i].GetComponent<Text>().color = unselectedColor;
        }
        textsSize = texts.Count - 1;
    }

    private void Update() {
        if (!Menu.isPaused) return;

        textComp = texts[wheelValue].GetComponent<Text>();
        textComp.color = selectedColor;

        if (Input.GetKeyDown("down")) {
            ClearText();
            wheelValue++;
            if (wheelValue > textsSize) wheelValue = 0;
            if (scrollable) ScrollHandler();
        } else if (Input.GetKeyDown("up")) {
            ClearText();
            wheelValue--;
            if (wheelValue < 0) wheelValue = textsSize;
            if (scrollable) ScrollHandler();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            string optionSelected = texts[wheelValue].gameObject.name;
            MenuChangeWindow mcw;
            
            if (optionSelected == "Resume") Menu.ResumeGame();
            else if (optionSelected == "Save") {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.Save();
            } else if (optionSelected == "Load") {
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.Load();
            }

            if (mcw = texts[wheelValue].GetComponent<MenuChangeWindow>()) {
                mcw.currentWindow.SetActive(false);
                mcw.windowHolder.SetActive(true);
            }
        }
    }

    private void ClearText() {
        textComp.color = unselectedColor;
    }

    private void ScrollHandler() {
        float top = this.GetComponent<RectTransform>().offsetMax.y;
        float yPos = texts[wheelValue].GetComponent<RectTransform>().anchoredPosition.y;
        float quotient = texts[textsSize - 1].GetComponent<RectTransform>().anchoredPosition.y / texts.Count;
        this.GetComponent<RectTransform>().offsetMax = new Vector2(0, -quotient * wheelValue);
    }

}
