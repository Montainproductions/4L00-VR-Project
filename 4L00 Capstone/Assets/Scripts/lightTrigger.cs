using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lightTrigger : MonoBehaviour
{
    [Header("Lights")]
    // Collect an Array of lights to be changed
    [SerializeField]
    private Light[] light;
    // Change the light's intensity to the given value
    [SerializeField]
    private float intensityChangeTo = 1f;
    // If we want to make the light's change gradually instead
    [Header("Additonal Options")]
    public bool gradualChange;
    [SerializeField]
    private float duration = 2f;

    // If the player enter's the collider of the object this script is attached to
    private void OnTriggerEnter(Collider other)
    {
        // Check for the player tag
        if (other.CompareTag("Player") == true)
        {
            // Check if we want to change the light's gradually
            if (gradualChange == true)
            {
                // The fade function requires the array of lights, the intensity we want to change to, and the time it'll take to change the intensity
                StartCoroutine(fade(Light, intensityChangeTo, duration));
                Debug.Log("Lights changing");
            }
            else
            {
                // For each light in the array, change it's intensity to new value given 
                for(int i = 0; i < Light.Length; i++)
                {
                    Light[i].intensity = intensityChangeTo;
                }
            }
        }
    }

    // Gradually Change the lights based on a given duration
    IEnumerator fade(Light[] lightToFade, float maxLuminosity, float duration)
    {
        // our minLuminosity is set to the first light in the array (i'm assuming all the lights will be at the same intensity initally)
        // (Contact Matt if this needs to be changed)
        float minLuminosity = lightToFade[0].intensity;
        // This will count the seconds that pass
        float counter = 0f;
        // While the seconds that pass are still below the duration limit, run the rest of this code
        while (counter < duration)
        {
            // Increment the counter by real seconds
            counter += Time.deltaTime;
            // Change the each light in the array of lights
            for(int i = 0; i < lightToFade.Length; i++)
            {
                // This changes the light's intentisty to the new intentisty over a certain duration
                lightToFade[i].intensity = Mathf.Lerp(minLuminosity, maxLuminosity, counter / duration);
            }  
            // IEnumerator's require a return value, but we don't need to return anything, so just pass null instead
            yield return null;
        }
    }


}
