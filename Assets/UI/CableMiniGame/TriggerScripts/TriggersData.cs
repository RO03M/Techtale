using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script stores the data order of the cables that was attached in the connector
//The default order of the cables ID was chosen based on the T568A order. So if blank with green is 0, full brown'id is 7
//Therefore, the T568A correct order is 01234567 and T568B correct order is 25034167
//                                      gGoBbOmM                            oOgBbGmM
public class TriggersData : MonoBehaviour {
    
    public static List<int?> cablesOrder = new List<int?>() {null, null, null, null, null, null, null, null};
    public bool isCorrect = false;

    private List<int?> T568A = new List<int?>() {0, 1, 2, 3, 4, 5, 6, 7};
    private List<int?> T568B = new List<int?>() {2, 5, 0, 3, 4, 1, 6, 7};

    private void Update() {
        CheckOrder();
    }

    private void CheckOrder() {
        for (int i = 0; i < 8; i++) {
            if (T568A[i] == cablesOrder[i]) isCorrect = true;
            else {
                isCorrect = false;
                return;
            }
        }
    }

}
