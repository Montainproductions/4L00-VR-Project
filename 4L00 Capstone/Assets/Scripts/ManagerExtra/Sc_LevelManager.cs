using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sc_LevelManager : MonoBehaviour{
    public static Sc_LevelManager Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced

    public GameObject pauseMenu, mainMenu;

    [SerializeField]
    private GameObject spawner, player;
    [SerializeField]
    private int SRSceneNumber;
    [SerializeField]
    public Light[] lightsInScene;

    public void Awake(){ //Whenever the script if first spawned in the game it will create the player.
        Instance = this; //Tells the singleton what game object its meant to be listening
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }

    public void SpawnPlayer(){
        GameObject p = Instantiate(player, spawner.transform.position, Quaternion.identity); //Create the player
    }

    public void GetPlayer(){

    }
    
    public void SafeRoom()
    {
        Sc_GameManager.Instance.GoToLevel(SRSceneNumber);
    }

    public void TurnOnOffLights()
    {
        Debug.Log("LightSwitch Working");
        for (int i = 0; i < lightsInScene.Length; i++)
        {
            lightsInScene[i].enabled = !lightsInScene[i].enabled;
            
        }
    }
}
