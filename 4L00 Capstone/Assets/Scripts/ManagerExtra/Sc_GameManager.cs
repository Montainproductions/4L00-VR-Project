using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_GameManager : MonoBehaviour{

    public static Sc_GameManager Instance{ get; private set; } //Singleton of the script/gameobject so that it can be referenced

    [HideInInspector]
    public int currentLevel; //Current Scene/level of the game

    [HideInInspector]
    public bool playIntroOnce;
    public bool playIntroOnceCoping;
    public bool playIntroOnceBreathing;

    //When the game object is first created. This is so that if another object is later created shortly after it can always find this script
    public void Awake(){
        if (Instance == null)
        {
            Instance = this; //Tells the singleton what game object its meant to be listening
        }
        else
        {
            Destroy(gameObject);
        }

        UnityEngine.Object.DontDestroyOnLoad(this); //Dont Destroy so that it can continuasly run this info
        //Why is it 6?
        currentLevel = SceneManager.sceneCountInBuildSettings; //Sets the current level 0 and must be placed where the game starts

        playIntroOnce = false;
        playIntroOnceCoping = false;
        playIntroOnceBreathing = false;
    }


    public void CopingRoom()
    {
        GoToLevel(4);
    }

    public void StartGame()
    {
        playIntroOnce = false;
        GoToLevel(1);
    }

    //Changes Scene/level to the one given usually by the door
    public void GoToLevel(int level){
        currentLevel = level; //Updates current Scene/level
        Debug.Log(level); //Confirms in debug.log what level it is going to
        SceneManager.LoadScene(level); //Changes the scene/level
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
