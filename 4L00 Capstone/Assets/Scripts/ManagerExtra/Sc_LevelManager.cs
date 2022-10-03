using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sc_LevelManager : MonoBehaviour{
    [SerializeField]
    private GameObject spawner, player;
    [SerializeField]
    private int sceneNumber;

    public void Awake(){ //Whenever the script if first spawned in the game it will create the player.
        SpawnPlayer();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("f2"))
        {
            SafeRoom();
        }
    }

    public void SpawnPlayer(){
        GameObject p = Instantiate(player, spawner.transform.position, Quaternion.identity); //Create the player
    }

    public void GetPlayer(){

    }
    
    public void SafeRoom()
    {
        Sc_GameManager.Instance.GoToLevel(sceneNumber);
    }
}
