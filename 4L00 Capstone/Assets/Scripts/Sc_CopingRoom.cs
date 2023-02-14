using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    IEnumerator TimerBeforePlayer()
    {
        yield return new WaitForSeconds(timerBefVideo);
        videoPlayer.Play();
        videoPlayer.isLooping = true;
        yield return null;
    }
}
