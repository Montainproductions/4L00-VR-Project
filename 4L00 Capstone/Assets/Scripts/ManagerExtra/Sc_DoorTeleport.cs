using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_DoorTeleport : MonoBehaviour{
    public int sceneNumber;
    
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Debug.Log("Hello");
            Sc_GameManager.Instance.GoToLevel(sceneNumber);
        }
    }

}
