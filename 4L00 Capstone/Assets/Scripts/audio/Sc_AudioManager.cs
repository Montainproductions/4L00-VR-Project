using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Sc_AudioManager : MonoBehaviour
{
    public static Sc_AudioManager Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced



    public AudioClip[] baseAudioClips;
    public AudioSource[] audioSources, extraSources;
    private int timer = 0;

    [Header("Audio Mixer")]
    //[SerializeField]
    //private bool changeAudioMixerVolume;
    [SerializeField]
    [Range(-20, 20)]
    private float newPanicRoomVolume, newAtriumVolume;
    [SerializeField]
    private AudioMixer audioMixer;

    public void Awake()
    {
        //Whenever the script if first spawned in the game it will create the player.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        StartCoroutine(PlayRandomIntervalSound());
        if (scene.name == "Atrium")
        {
            audioMixer.SetFloat("musicVolume", newAtriumVolume);
            PlayAudio(0,0);
        }
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

    public void PlayAudio(AudioClip audioclip)
    {
        AudioSource audioSource = GetNextSource();
        audioSource.clip = audioclip;
        audioSource.Play();
    }

    public void PlayAudio(int audioSourceVal, int audioClipVal)
    {
        AudioSource audioSource = extraSources[audioSourceVal];
        audioSource.clip = baseAudioClips[audioClipVal];
        audioSource.Play();
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

    private AudioSource ExtraAudioSource()
    {
        foreach (AudioSource s in extraSources)
        {
            if (!s.isPlaying)
                return s;
        }
        extraSources[0].Stop();
        return extraSources[0];
    }

    private AudioClip GetRandomClip()
    {
        return null;
    }

    public void CreateAudioSource(GameObject obj, AudioSource audioSource, bool followObject, bool destroyTheObject, bool triggerOnlyOnce)
    {
        // Save at current object position as a variable
        //position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        AudioSource ao;
        // Check if we want the Audio to follow the object through it's movement
        if (followObject == true)
        {
            // Spawns an Audio Source as a Child of this GameObject
            //ao = Instantiate(audioSource, position, Quaternion.identity, obj.transform);
            //PlayAudio(ao);
        }
        else
        {
            // Spawn Audio Source at GameObjects location
            //ao = Instantiate(audioSource, position, Quaternion.identity);
            //PlayAudio(ao);
        }
        // Incase you want to destroy the object after spawning the sound source
        if (destroyTheObject == true)
        {
            // Destroy this GameObject
            Destroy(obj);
        }
        // Removes Script from the object to prevent the script from being called again
        // Use only if you want to keep the object around after triggering the Audio
        if (triggerOnlyOnce == true)
        {
            // Remove's this script from the pin
            Destroy(this);
        }
    }

    public void ChangeAudioMixer()
    {
        Debug.Log("Audio Changed");
        //audioMixer.GetFloat("panicRoomVolume", out currentAudioMixerVolume);

        audioMixer.SetFloat("panicRoomVolume", newPanicRoomVolume);
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
        //StartCoroutine(PlayRandomIntervalSound());
        yield return null;
    }
}