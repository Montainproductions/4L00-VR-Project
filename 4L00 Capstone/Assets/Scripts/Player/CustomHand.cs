using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomHand : MonoBehaviour
{

    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private XRInteractorLineVisual lineVisual;
    [SerializeField] private LineRenderer lineRenderer;

    private void Update()
    {
        if (!rayInteractor.IsOverUIGameObject())
        {
            lineVisual.enabled = false;
            lineRenderer.enabled = false;
        }
        else
        {
            lineVisual.enabled = true; 
            lineRenderer.enabled = true;
        }
    }
}
