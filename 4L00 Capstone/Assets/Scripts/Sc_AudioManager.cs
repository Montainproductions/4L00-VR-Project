using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) {
            int idClip = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[idClip];
            audioSource.Play();
        }
    }
}
