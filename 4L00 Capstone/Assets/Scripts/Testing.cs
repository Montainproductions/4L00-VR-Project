using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] private Blink blinkScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            blinkScript.StartBlink();
        }
    }
}
