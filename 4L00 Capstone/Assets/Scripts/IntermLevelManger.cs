using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntermLevelManger : MonoBehaviour
{
    [SerializeField] private ShaderEditing[] listOfHighlightingObjects;

    private int panicRoomState = 0;

    private void Start()
    {
        panicRoomState = 0;
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

}
