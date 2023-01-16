using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntermLevelManger : MonoBehaviour
{
    [SerializeField] private ShaderEditing[] listOfHighlightingObjects;

    [SerializeField] private XRGrabInteractable xr;

    
    [SerializeField] private InteractionLayerMask changedInteractionLayerMask;
    private InteractionLayerMask orignalInteractionLayerMask;

    private float timer;
    private float maxTime = 3f;
    private bool invert;

    private int panicRoomState = 0;

    private void Start()
    {
        panicRoomState = 0;
        orignalInteractionLayerMask = xr.interactionLayers;
        timer = maxTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if (!invert)
            {
                removeInteractionLayers();
                invert = !invert;
                timer = maxTime;
            }
            else
            {
                returnInteractionLayers();
                invert = !invert;
                timer = maxTime;
            }
            
        }
    }

    public void StartObjectHighLighting()
    {
        listOfHighlightingObjects[panicRoomState].StartHighlighting();
    }

    public void StopObjectHighLighting()
    {
        foreach(var highlightingObject in listOfHighlightingObjects)
        {
            highlightingObject.StopHighlighting();
        }
    }

    public void IncreasePanicRoomState(int stateNumber)
    {
        panicRoomState = stateNumber;
    }

    public void removeInteractionLayers()
    {
        xr.interactionLayers = changedInteractionLayerMask;
        Debug.Log("Interaction layer changed to nothing");
    }

    public void returnInteractionLayers()
    {
        xr.interactionLayers = orignalInteractionLayerMask;
        Debug.Log("Interaction layer changed to OCDClothes");
    }

}
