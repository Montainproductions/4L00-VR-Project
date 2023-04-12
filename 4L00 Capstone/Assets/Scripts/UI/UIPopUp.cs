using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUp : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup testCanvasGroup;

    private void Start()
    {
        FadeUIGroupOut(testCanvasGroup);
    }

    private void MakeUIAppear(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
    }

    private void FadeUIGroupOut(CanvasGroup canvasGroup)
    {
        float fadeTime = 1f;
        StartCoroutine(FadeOutObject(canvasGroup, fadeTime));
    }


    private IEnumerator FadeOutObject(CanvasGroup canvasGroup, float fadeTime)
    {
        while(canvasGroup.alpha >= 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeTime;
        }
        yield return null;
    }
}
