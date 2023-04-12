using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlurEffect : MonoBehaviour
{

    [SerializeField]
    private VolumeProfile profile;

    private DepthOfField depthOfField;

    private void Start()
    {
        profile.TryGet<DepthOfField>(out DepthOfField depthOfFieldout);
        depthOfField = depthOfFieldout;
    }

    public void ChangeBlur(float newFocalLength, float duration)
    {
        StartCoroutine(ChangeDepthOfFieldFocalLength(newFocalLength, duration));
    }

    private IEnumerator ChangeDepthOfFieldFocalLength(float newFocalLength, float duration)
    {
        // Initialize timer
        var counter = 0f;
        var originalFocalLength = depthOfField.focalLength.GetValue<float>();

        // Only pulsate while bool is true
        while (counter < duration)
        {
            // Lerp between the starting power value and the end power value over time
            var pow = Mathf.Lerp(originalFocalLength, newFocalLength, counter / duration);
            // Change the DephOfField's flocalLength value now
            depthOfField.focalLength.Override(pow);
            // Increase the Counter
            counter += Time.deltaTime;
            // Resume operation the until the following frame
            yield return null;
        }
    }
}
