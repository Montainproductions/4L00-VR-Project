using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Transform playerCameraTransform; // reference of the playercamera
    [SerializeField]
    private Transform objectGrabPointTransform; //Referenc of the grab point on the player
    [SerializeField]
    private LayerMask pickUpLayerMask; // Select everything but the player and post-processing layer
    [SerializeField]
    private LayerMask buttonLayerMask;

    private ObjectGrabbable objectGrabbable;
    private ButtonInteract button;

    private void Update()
    {
        //Debug.Log(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, 3, pickUpLayerMask));
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If not carrying an object, try to grab an object
            if ( objectGrabbable == null)
            {
                float interactDistance = 5f;
                // if the raycast hits an object within the list of applicable layers then check if that object has the scipt "objectGrabbable"
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, pickUpLayerMask))
                {
                    //Debug.Log("Picking up");
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        Debug.Log("Pickup");
                        // Grab the object and set it to the GrabPoint attached to the player
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit racastHit, interactDistance, buttonLayerMask))
                {
                    Debug.Log("Stage1");
                    if (raycastHit.transform.TryGetComponent(out button))
                    {
                        Debug.Log("Stage2");
                        button.LightSwitchToggle();
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
