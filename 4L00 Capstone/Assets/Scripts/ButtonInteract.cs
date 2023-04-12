using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public void LightSwitchToggle()
    {
        Debug.Log("Stage3");
        Sc_PanicDisorderR1.Instance.TurnOnOffLights();
    }
}
