using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sc_AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource[] audioSources;
    private GameObject[] audioObjs;
    private bool[] isPlaying;
    private int timer = 0;
    public int maxInterval;
    public int minInterval;
    private Coroutine audioCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        audioCoroutine = StartCoroutine(PlayRandomIntervalSound());
    }
    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < audioSources.Length; i++){
        //    if (audioSources[i].isPlaying) return;
        //    int idClip = Random.Range(0, audioClips.Length);
        //    if(!isPlaying[idClip]){
        //        PlayAudio(audioSources[i], audioClips[idClip]);
        //    }
        //}
    }
    private IEnumerator PlayRandomIntervalSound()
    {
        //Set the timer to a number between max and min
        if (timer == 0)
        {
        }
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
        AudioClip clip = GetRandomClip();
        PlayAudio(clip);
        audioCoroutine = StartCoroutine(PlayRandomIntervalSound());
        yield return null;
    }
    public void PlayAudio(AudioClip audioclip)
    {
        AudioSource audioSource = GetNextSource();
        audioSource.clip = audioclip;
        audioSource.Play();
    }
    public void PlayNewAudio()
    {
        audioObjs = GameObject.FindGameObjectsWithTag("Audio");
    }
    private AudioSource GetNextSource()
    {
        foreach (AudioSource s in audioSources)
        {
            if (!s.isPlaying)
                return s;
        }
        audioSources[0].Stop();
        return audioSources[0];
    }
    private AudioClip GetRandomClip()
    {
        return null;
    }
}