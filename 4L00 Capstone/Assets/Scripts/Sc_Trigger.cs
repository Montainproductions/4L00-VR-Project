using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_Trigger : MonoBehaviour
{
    IEnumerator DingCashier()
    {
        yield return new WaitForSeconds(0.5f);
        Sc_AudioManager.Instance.PlayAudio(2, 2);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Room1(PanicDisorder)" && other.CompareTag("EggCarton"))
        {
            StartCoroutine(DingCashier());
            //Sc_AudioManager.Instance.PlayAudio(2, 2);
        }
    }
    // If the player enter's the collider of the object this script is attached to
    private void OnTriggerExit(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Room1(PanicDisorder)")
        {
            // Check for the player tag
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Sc_PanicDisorderR1.Instance.Phase2(30));
            }
        }
    }
}
