using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BlurEffect : MonoBehaviour
{

    private float focalLenght = 100f;
    //[SerializeField] private VolumeParameter volumeParameter;
    [SerializeField] private VolumeProfile profile;


    private void Start()
    {
        profile.TryGet<DepthOfField>(out DepthOfField depthOfField);
        depthOfField.focalLength.Override(100f);
        depthOfField.SetAllOverridesTo(true);
        //depthOfField.focalLength.SetValue(volumeParameter);
        //depthOfField.focalLength.Override(100f);
    }

}
