using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_WallMoving : MonoBehaviour{
    public int id; //ID of wall (Current Object) used in events system
    public GameObject wall, finalDestination; //The current wall object and the place it will go
    public float speed; //Speed of walls
    private bool canMove; //Boolean that checks if the walls are allowed to move. This is so that it can continuasly run instead of doing it once.
    public Vector3 wallV3, destinationV3; //The Vector 3 of both the wall and the final destination

    // Start is called before the first frame Normally this is done when the level is first loaded
    void Start(){
        Sc_GameEvents.Instance.wallColapsing += MoveWall; //Adds to the game event list shinanigens
        wallV3 = wall.transform.position; //Gets current position (Vector 3) of the wall and save it into a variable
        destinationV3 = finalDestination.transform.position; //Similar to the wallV3 it will get the current position (Vector3)
        canMove = false; //Sets the canMeve variable to false so that it dosent automaticly start moving the wall untill the Move Wall method is called
    }

    // Update is called once per frame now how often a frame is depends on how optimized the game is
    void Update(){
        if (canMove){ //If it can move then move the wall
            wallV3 = Vector3.MoveTowards(wallV3, destinationV3, speed * Time.deltaTime); //Slowly moves the wall from where it is to its final destination
        }
    }

    //When called it will flip the variable to true so that the wall can start moving
    void MoveWall(int id){
        if (id == this.id){ //Checks if ID recived is same as internal ID (Allows for multiple walls to be moved)
            canMove = true; //Will turn the can move variable into true
        }
    }
}
