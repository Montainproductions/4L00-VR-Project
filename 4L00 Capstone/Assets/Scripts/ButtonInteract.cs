using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    [SerializeField]
    private Sc_LevelManager levelManager;
    [SerializeField]
    private bool lightSwitch;

    public void LightSwitchToggle()
    {
        Debug.Log("Stage3");
        levelManager.TurnOnOffLights();
    }
}
