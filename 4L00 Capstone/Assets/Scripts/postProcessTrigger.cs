using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postProcessTrigger : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume PostProcessing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PostProcessing.enabled = true;
        }
    }
}
