using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script gets all the important info about the player for the save system
[System.Serializable]
public class PlayerData {
    
    public float[] position;

    public PlayerData(Player player) {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }

}
