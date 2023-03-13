using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class Sc_CopingRoom : MonoBehaviour
{
    [SerializeField]
    private float timerBefVideo;

    [SerializeField]
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerBeforePlayer());

        if (!Sc_GameManager.Instance.playIntroOnceCoping)
        {
            Sc_AudioManager.Instance.PlayAudio(0, 0);
            Sc_GameManager.Instance.playIntroOnceCoping = true;
        }
    }


    IEnumerator TimerBeforePlayer()
    {
        yield return new WaitForSeconds(timerBefVideo);
        videoPlayer.Play();
        videoPlayer.isLooping = true;
        if (!Sc_GameManager.Instance.playIntroOnceBreathing)
        {
            Sc_AudioManager.Instance.PlayAudio(1, 1);
            Sc_GameManager.Instance.playIntroOnceBreathing = true;
        }
        yield return null;
    }
}
