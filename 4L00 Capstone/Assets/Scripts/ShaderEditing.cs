using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShaderEditing : MonoBehaviour
{
    // The material to be edited
    [SerializeField] Material material;

    // Set the starting and end values of the pulse
    [SerializeField] private float startingFresnelPower = 15f;
    [SerializeField] private float endFresnelPower = 0.72f;

    // Starting Colour
    [SerializeField] private Color startingColor;

    // MaxTimer Value
    [SerializeField] private float maxCounter = 5f;

    // State Bools
    [SerializeField] private bool pulsate;
    private bool inverse = false;


    private void Start()
    {
        // Reset material values
        material.SetFloat("_FresnelPower", startingFresnelPower);
        material.SetColor("_FresnelColour", startingColor);
        // pulse on start if needed
        if (pulsate)
        {
            // Use a coroutine to lerp over time as it's better for running animations over time
            StartCoroutine(HighlightObject(startingFresnelPower, endFresnelPower, maxCounter));
        }
        
    }

    private IEnumerator HighlightObject(float startPower, float endPower, float maxTime)
    {
        // Initialize timer
        var counter = 0f;

        // Only pulsate while bool is true
        while (pulsate)
        {
            // If inverse is false then continue
            if (!inverse)
            {
                // Lerp the Fresnel Power over the value in maxTime
                if (counter < maxTime)
                {
                    // Lerp between the starting power value and the end power value over time
                    var pow = Mathf.Lerp(startPower, endPower, counter / maxTime);
                    // Change the material's float value now
                    material.SetFloat("_FresnelPower", pow);
                    // Increase the Counter
                    counter += Time.deltaTime;
                    // Resume operation the until the following frame
                    yield return null;
                }
                else
                {
                    // Once the lerp is done inverse the opteration
                    inverse = !inverse;
                    // reset timer
                    counter = 0f;
                }
            }
            else
            {
                // Reverse the lerp to create a pulse effect
                if (counter < maxTime)
                {
                    // Lerp between the ending power and starting power over time
                    var pow = Mathf.Lerp(endPower, startPower, counter / maxTime);
                    // Change the maertial's float value now
                    material.SetFloat("_FresnelPower", pow);
                    // Increease the Counter
                    counter += Time.deltaTime;
                    // Resume operation the until the following frame
                    yield return null;
                }
                else
                {
                    // Loop back to the beginning
                    inverse = !inverse;
                    // Reset counter
                    counter = 0f;
                }
            }
        }
        yield return null;
    }

    // Allow over other scripts to stop and start the pulse
    public void StopHighlighting()
    {
        // Stop the pulse
        pulsate = false;
        // change the FresnelColour to black which makes the effect invisible
        material.SetColor("_FresnelColour", Color.black);
    }

    public void StartHighlighting()
    {
        // Start the pulse
        pulsate = true;
        // Change the FrenselColour back to yellow for the highlight effect
        material.SetColor("_FresnelColour", Color.yellow);
        // Start Coroutine
        StartCoroutine(HighlightObject(startingFresnelPower, endFresnelPower, maxCounter));
    }
}
