using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerVibration : MonoBehaviour
{

    //[SerializeField] private XRController xrController;
    [SerializeField] private ActionBasedController abc;


    private void Start()
    {
        //xrController.SendHapticImpulse(1f, 2f);
        abc.SendHapticImpulse(1f, 2f);
    }


}
