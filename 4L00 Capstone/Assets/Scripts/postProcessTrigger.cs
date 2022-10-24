using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postProcessTrigger : MonoBehaviour
{

    [SerializeField]
    private PostProcessProfile PostProfile;
    [SerializeField]
    private float vignetteNewIntensity = 0.5f;
    [SerializeField]
    private float chromaticAberrationNewIntensity = 0.88f;

    private Vignette vg;
    private ChromaticAberration ca;

    private void Start()
    {
        PostProfile.TryGetSettings(out vg);
        PostProfile.TryGetSettings(out ca);
        vg.intensity.value = 0f;
        ca.intensity.value = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vg.intensity.value = vignetteNewIntensity;
            ca.intensity.value = chromaticAberrationNewIntensity;
        }

    }
}
