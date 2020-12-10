using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//really an easy way out just to get the position from the player for the save system
public class Player : MonoBehaviour {

    public Vector2 position;

    public void Save() {
        SaveSystem.SavePlayer(this);
    }
    
    public void Load() {
        PlayerData data = SaveSystem.LoadPlayer();
        position = new Vector2(data.position[0], data.position[1]);
        this.transform.position = position;
    }

}
