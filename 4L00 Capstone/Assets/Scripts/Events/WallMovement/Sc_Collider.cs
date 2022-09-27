using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Collider : MonoBehaviour{
    public int id;

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){ //Checks the Tag of the colliding object and if it is the same as the player then continue with the code inside the if statment
            Debug.Log("Hello"); //Will print in the console the word "Hello"
            Sc_GameEvents.Instance.MoveWall(id);
        }
    }
}
