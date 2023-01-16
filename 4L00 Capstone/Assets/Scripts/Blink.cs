using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{

    [SerializeField] private Image blinkImage;
    [SerializeField] private float blinkDuration;

    private bool blinking = false;
    private float timer;

    private void Start()
    {
        blinkImage.enabled = false;
    }

    private void Update()
    {
        if (blinking)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                StopBlink();
            }
        }
    }

    public void StartBlink()
    {
        blinkImage.enabled = true;
        blinking = true;
        timer = blinkDuration;
    }

    public void StopBlink()
    {
        blinkImage.enabled = false;
        blinking = false;
    }
}
