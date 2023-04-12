using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GameEvents : MonoBehaviour{
    public static Sc_GameEvents Instance{get; private set;} //Create an instance of the Sc_GameEvent so that it can be called with out acutally needing to create unecessary clutter in the code

    //Once the object is created it will run this bit of code setting up the singleton
    public void Awake(){
        Instance = this; //Connecting the singleton instance to itself

        UnityEngine.Object.DontDestroyOnLoad(this); //Wont destroy the Object even when so that other code 
    }

    public event Action<int> moveWall; //The event of moving the wall
    public void MoveWall(int id){
        if (moveWall != null){
            moveWall(id);
        }
    }
}
