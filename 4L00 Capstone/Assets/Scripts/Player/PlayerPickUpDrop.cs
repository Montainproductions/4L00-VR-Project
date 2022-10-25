using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField]
    private Transform playerCameraTransform; // reference of the playercamera
    [SerializeField]
    private Transform objectGrabPointTransform; //Referenc of the grab point on the player
    [SerializeField]
    private LayerMask pickUpLayerMask; // Select everything but the player and post-processing layer

    private ObjectGrabbable objectGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If not carrying an object, try to grab an object
            if ( objectGrabbable == null)
            {
                float pickUpDistance = 3f;
                // if the raycast hits an object within the list of applicable layers then check if that object has the scipt "objectGrabbable"
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        // Grab the object and set it to the GrabPoint attached to the player
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                // If currently carrying something, drop it
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
            
        }
    }
}
