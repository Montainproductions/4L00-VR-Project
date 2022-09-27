using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class basicScript1 : MonoBehaviour
{

    // Set variables
    private Rigidbody rb;
    public GameObject cam;
    public Boolean isGrounded;
    public LayerMask GroundLayer;
    public float sphereRadius;

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
        if (Input.GetKey("d") == true) {
            Move(new Vector2(1, 0));
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
        // Checks if Player is grounded, if yes then jumping is enabled
        IsGrounded();
        if (Input.GetKeyDown("space") == true)
        {
            if (isGrounded == true)
            {
                Jump();
            }
        }

        // Sets Camera movement to player's position
        float sphereX = transform.position.x;
        float sphereY = transform.position.y;
        float sphereZ = transform.position.z;
        cam.transform.position = new Vector3(sphereX, sphereY, sphereZ - 5);
    }

    private void Move(Vector2 direction)
    {
        // Use the Rigidbody addForce to move the Player object depending on key input
        rb.AddForce(new Vector3(direction.x, 0, direction.y) * 0.5f, ForceMode.Force);
    }
    private void Jump()
    {
        // Add upword force
        rb.AddForce(new Vector3(0, 1, 0) * 5f, ForceMode.Impulse);


    }
    // Defines a sphere around the player and checks if there are any collider's with the Ground tag instecting that sphere
    private void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.position, sphereRadius, GroundLayer);
    }
    
}
