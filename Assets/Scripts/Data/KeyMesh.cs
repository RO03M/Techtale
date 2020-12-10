using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will return the Sprite according to the keycode passed
public class KeyMesh : MonoBehaviour {
    public Sprite[] keySprites;
    public string teste;
    private KeyCode[] keyCodes = new KeyCode[] {
        KeyCode.A, 
        KeyCode.B, 
        KeyCode.C, 
        KeyCode.D, 
        KeyCode.E, 
        KeyCode.F, 
        KeyCode.G, 
        KeyCode.H, 
        KeyCode.I, 
        KeyCode.J, 
        KeyCode.K, 
        KeyCode.L, 
        KeyCode.M, 
        KeyCode.N, 
        KeyCode.O, 
        KeyCode.P, 
        KeyCode.Q, 
        KeyCode.R, 
        KeyCode.S, 
        KeyCode.T, 
        KeyCode.U, 
        KeyCode.V, 
        KeyCode.W, 
        KeyCode.X, 
        KeyCode.Y, 
        KeyCode.Z
    };

    public Sprite GetKeySprite(KeyCode key) {
        int index = Array.IndexOf(keyCodes, key);
        return keySprites[index];
    }

}
