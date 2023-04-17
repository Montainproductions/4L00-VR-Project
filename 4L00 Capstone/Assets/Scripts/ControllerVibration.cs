using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVibration : MonoBehaviour
{

    [SerializeField] private ActionBasedController leftController, rightController;

    private bool rumbleForever = false;

    private void Update()
    {
        if (rumbleForever)
        {
            StartControllerVibrations(0.75f, 0.1f);
        }
        
    }
    // amplitude must be between 0-1 for it to work
    public void StartControllerVibrations(float amplitude, float duration)
    {
        Debug.Log("Controller Vibrations");
        leftController.SendHapticImpulse(amplitude, duration);
        rightController.SendHapticImpulse(amplitude, duration);
    }

    public void RumbleControllersForever()
    {
        rumbleForever = true;
    }
}
