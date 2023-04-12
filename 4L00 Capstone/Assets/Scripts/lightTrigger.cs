using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lightTrigger : MonoBehaviour
{

    // If the player enter's the collider of the object this script is attached to
    private void OnTriggerExit(Collider other)
    {
        // Check for the player tag
        if (other.CompareTag("Player")){
            if (SceneManager.GetActiveScene().name == "Room1(PanicDisorder)")
            {
                Debug.Log("Starting phase 2");
                StartCoroutine(Sc_PanicDisorderR1.Instance.Phase2(30));
            }
        }
    }
}
