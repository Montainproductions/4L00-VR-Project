using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVibration : MonoBehaviour
{

    //[SerializeField] private XRController xrController;
    [SerializeField] private ActionBasedController leftController;
    [SerializeField] private ActionBasedController rightController;

    private float timer;


    private void Start()
    {
        //xrController.SendHapticImpulse(1f, 2f);
        leftController.SendHapticImpulse(1f, 2f);
        timer = 4f;
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Debug.Log("Start Haptics now");
            StartControllerVibrations();
            timer = 4f;
        }
    }


    public void StartControllerVibrations()
    {
        leftController.SendHapticImpulse(2f, 3f);
        rightController.SendHapticImpulse(2f, 3f);
    }

}
