using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_DoorTeleport : MonoBehaviour{
    public int sceneNumber; //The scene that the game will change when the player collides with a box collider
    
    //When something hits the box trigger that this script is attached with it will trigger this method
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){ //Checks the Tag of the colliding object and if it is the same as the player then continue with the code inside the if statment
            Debug.Log("Hello"); //Will print in the console the word "Hello"
            Sc_GameManager.Instance.GoToLevel(sceneNumber); //Will grab the singleton of Game Manager and run the method to changle level and to which one given by the sceneNumber int value
        }
    }
}
