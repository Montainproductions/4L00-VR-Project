using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lightTrigger : MonoBehaviour
{
    [SerializeField]
    private Light Light;

    [SerializeField]
    private float intensityChangeTo = 1f;

    public bool gradualChange;
    [SerializeField]
    private float rampUpSpeed = 2f;
    private float tempCurrentValue = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            if (gradualChange == true)
            {
                while (tempCurrentValue < rampUpSpeed)
                {
                    tempCurrentValue += Time.deltaTime;
                    Light.intensity = Mathf.Lerp(Light.intensity, intensityChangeTo, tempCurrentValue / rampUpSpeed);
                    Debug.Log(Light.intensity);
                    Light.color = Color.red;
                }
                
            }
            else
            {
                Light.intensity = intensityChangeTo;
            }
        }
    }
}
