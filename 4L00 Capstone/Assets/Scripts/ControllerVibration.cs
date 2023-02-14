using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVibration : MonoBehaviour
{

    [SerializeField] private ActionBasedController leftController, rightController;

    // amplitude must be between 0-1 for it to work
    public void StartControllerVibrations(float amplitude, float duration)
    {
        Debug.Log("Controller Vibrations");
        leftController.SendHapticImpulse(amplitude, duration);
        rightController.SendHapticImpulse(amplitude, duration);
    }
}
