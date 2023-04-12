using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_WallMoving : MonoBehaviour{
    public int id; //The id to connect the specific trigger with its own wall
    public GameObject wall, finalDestination; //The current wall object and the place it will go
    public float speed; //Speed of walls

    private bool canMove; //Boolean that checks if the walls are allowed to move. This is so that it can continuasly run instead of doing it once.
    
    public void Awake(){
        Sc_GameEvents.Instance.moveWall += MoveWall; //Adds the wall script to the list of events
    }

    // Start is called before the first frame Normally this is done when the level is first loaded
    void Start(){
        canMove = false; //Sets the canMeve variable to false so that it dosent automaticly start moving the wall untill the Move Wall method is called
    }

    // Update is called once per frame now how often a frame is depends on how optimized the game is
    void Update(){
        if (canMove){ //If it can move then move the wall
            transform.position = Vector3.MoveTowards(transform.position, finalDestination.transform.position, speed * Time.deltaTime); //Slowly moves the wall from where it is to its final destination
        }
    }

    public void MoveWall(int id){ //Checks if the wall being called is its self and then makes the canMove true
        if(id == this.id){
            canMove = true;
        }
    }

    public void OnDestroy(){
        Sc_GameEvents.Instance.moveWall -= MoveWall; //If the wall is destroyed then it will take it out of the event list.
    }
}
