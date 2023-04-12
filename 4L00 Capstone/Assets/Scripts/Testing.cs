using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] private Blink blinkScript;
    [SerializeField] private BlurEffect blurEffect;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            blinkScript.StartBlink();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            blurEffect.ChangeBlur(100f,5f);
        }
    }
}
