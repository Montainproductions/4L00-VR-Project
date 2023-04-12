using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody; // Reference on the object's rigidbody
    private Transform objectGrabPointTransform; // local Reference of the Grab Point on the player

    private void Awake()
    {
        // When this script is loaded get the RigidBody component
        objectRigidbody = GetComponent<Rigidbody>();
    }
    
    // Grabs Object
    public void Grab(Transform objectGrabPointTransform)
    {
        Debug.Log("Germany");
        // Set the local grabpoint reference to the grabpoint given 
        this.objectGrabPointTransform = objectGrabPointTransform;
        // Remove Any forces applying to the object to avoid any weird jittering
        objectRigidbody.useGravity = false;
        objectRigidbody.velocity = new Vector3(0, 0, 0);
        objectRigidbody.isKinematic = true;
        // Remove any collision between the player and the object to avoid jittering
        Physics.IgnoreLayerCollision(3, 8, true);
    }

    //Drops Object
    public void Drop()
    {
        // Removes any grab point reference
        this.objectGrabPointTransform = null;
        // Reset all variables that were changed when grabbing
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
        // Re-enable player and object collision
        Physics.IgnoreLayerCollision(3, 8, false);
    }

    private void FixedUpdate()
    {
        // If holding an object, move it
        if (objectGrabPointTransform != null)
        {
            // Smoothly move the object's position to the Grab Point
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, objectGrabPointTransform.rotation, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
            objectRigidbody.MoveRotation(newRotation);
        }
    }
}
