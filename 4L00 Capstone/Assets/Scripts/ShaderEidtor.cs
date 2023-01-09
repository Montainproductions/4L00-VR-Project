using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ShaderEidtor : MonoBehaviour
{
    [SerializeField] Material material;

    private float orignalFresnalPowerValue;
    private float newFresnalPowerValue = 0.72f;
    private float inputNewFresnelValue;

    private float maxCounter = 5f;

    private bool inverse;

    private void Start()
    {
        material.SetFloat("_Fresnel_Power", 4f);
        StartCoroutine(HighlightObject(newFresnalPowerValue, maxCounter));
    }

    private void Update()
    {
        if (material.GetFloat("_Fresnel_Power") == newFresnalPowerValue)
        {
            StopCoroutine("HighlightObject");
            Debug.Log("Courtuine Stopped");
        }
    }

    private IEnumerator HighlightObject(float targetPower, float maxTime)
    {
        orignalFresnalPowerValue = orignalFresnalPowerValue = material.GetFloat("_Fresnel_Power");

        var counter = 0f;

        while (counter <= maxTime)
        {
            var pow = Mathf.Lerp(orignalFresnalPowerValue, targetPower, counter);
            material.SetFloat("_Fresnel_Power", pow);
            counter += Time.deltaTime / maxTime;
            yield return null;
        }

        counter = 0f;
        while (counter <= maxTime)
        {
            var pow = Mathf.Lerp(targetPower, orignalFresnalPowerValue, counter);
            material.SetFloat("_Fresnel_Power", pow);
            counter += Time.deltaTime / maxTime;
            yield return null;
        }
    }
}
