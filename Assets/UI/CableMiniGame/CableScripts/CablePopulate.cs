using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script creates all the cable bases that appears on the bottom of rj45 object
public class CablePopulate : MonoBehaviour {
    
    public Sprite[] sprites = new Sprite[8];
    public Material[] materials = new Material[8];

    private List<int> spritesNumerable = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7};

    private void Start() {
        for (int i = 0; i < 8; i++) {
            CreateCable();
        }
    }

    private void CreateCable() {
        GameObject cableObj = new GameObject("Cable base");
        cableObj.transform.SetParent(this.transform);
        cableObj.transform.localScale = Vector3.one;
        CreateCableLine ccl = cableObj.AddComponent<CreateCableLine>();
        cableObj.AddComponent<Button>();
        Image cableImage = cableObj.AddComponent<Image>();
        int index = GetRandomNum();
        cableImage.sprite = sprites[index];
        ccl.SetMaterial(materials[index]);
        ccl.cableBaseID = index;
    }

    private int GetRandomNum() {
        int randomInput = Random.Range(0, spritesNumerable.Count - 1);
        int randomValue = spritesNumerable[randomInput];
        spritesNumerable.RemoveAt(randomInput);
        return randomValue;
    }

}
