using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxBehaviour : MonoBehaviour {

    private Text m_Text;

    public void SetText(string text) {
        m_Text.text = text;
    }

}
