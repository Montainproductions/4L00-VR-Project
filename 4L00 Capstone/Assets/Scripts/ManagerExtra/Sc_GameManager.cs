using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_GameManager : MonoBehaviour{

    public static Sc_GameManager Instance{ get; private set; }

    public int currentLevel;

    public void Awake(){
        Instance = this;
    }

    // Start is called before the first frame update
    void Start(){
        currentLevel = 0;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void GoToLevel(int level){
        currentLevel = level;
        Debug.Log(level);
        SceneManager.LoadScene(level);
    }
}
