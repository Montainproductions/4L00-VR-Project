using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicScript1 : MonoBehaviour
{

    // Set variables
    private Rigidbody rb;
    public GameObject cam;
    
    // Called on first frame
    void Start()
    {
        // Set rb as the Player's Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player inputs from the WASD and Space keys
        if(Input.GetKey("d") == true){
            Move(new Vector2(1,0));
        }
        if (Input.GetKey("a") == true)
        {
            Move(new Vector2(-1, 0));
        }
        if (Input.GetKey("w") == true)
        {
            Move(new Vector2(0, 1));
        }
        if (Input.GetKey("s") == true)
        {
            Move(new Vector2(0, -1));
        }
        if (Input.GetKeyDown("space") == true)
        {
            Jump();
        }

        // Sets Camera movement to player's position
        float sphereX = transform.position.x;
        float sphereY = transform.position.y;
        float sphereZ = transform.position.z;
        cam.transform.position = new Vector3(sphereX, sphereY, sphereZ-5);
    }

    private void Move(Vector2 direction)
    {
        // Use the Rigidbody addForce to move the Player object
        rb.AddForce(new Vector3(direction.x, 0, direction.y) * 1f, ForceMode.Force);
    }
    private void Jump()
    {
        // Add upword
        rb.AddForce(new Vector3(0, 1, 0) * 5f, ForceMode.Impulse);
    }
}
