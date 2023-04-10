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

    //Audio mixer
    [Header("Audio Mixer")]
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    [Range(-20, 20)]
    private float targetPanicRoomVolume, newAtriumVolume;
    private float currentVolumeLevel;
    private bool setNewPanicRoomAudio;

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
        setNewPanicRoomAudio = false;
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

        if (setNewPanicRoomAudio && currentVolumeLevel < targetPanicRoomVolume)
        {
            currentVolumeLevel = Mathf.Lerp(currentVolumeLevel, targetPanicRoomVolume, Time.deltaTime);
            audioMixer.SetFloat("panicRoomVolume", currentVolumeLevel);
            Debug.Log(currentVolumeLevel);
        }else if(currentVolumeLevel > targetPanicRoomVolume)
        {
            setNewPanicRoomAudio = false;
        }
    }

    //Plays the given audio clip
    public void PlayAudio(AudioClip audioclip)
    {
        AudioSource audioSource = GetNextSource();
        audioSource.clip = audioclip;
        audioSource.Play();
    }

    //Play the audio clip from specific array in position given and uses the audio source from the audio source array.
    public void PlayAudio(int audioSourceVal, int audioClipVal)
    {
        AudioSource audioSource = extraSources[audioSourceVal];
        audioSource.clip = baseAudioClips[audioClipVal];
        audioSource.Play();
    }

    //Returns the next audio source that isnt playing a sound from the array of sources
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

    //Grabs a audio source that isnt playing audio from the extra audio sources array
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

    //Changes the volume of the audio mixer
    public void ChangeAudioMixer()
    {
        Debug.Log("Audio Changed");
        //audioMixer.GetFloat("panicRoomVolume", out currentAudioMixerVolume);
        //audioMixer.SetFloat("panicRoomVolume", newPanicRoomVolume);

        //float targetVolume = targetPanicRoomVolume + 10;
        //float volumeChangeDuration = 2f;
        //IncreasePanicRoomVolume(targetPanicRoomVolume, volumeChangeDuration);

        audioMixer.GetFloat("panicRoomVolume", out currentVolumeLevel);
        setNewPanicRoomAudio = true;
    }

    /*private void IncreasePanicRoomVolume(float targetVolumeLevel, float duration)
    {
        audioMixer.GetFloat("panicRoomVolume", out currentVolumeLevel);
        setNewPanicRoomAudio = true;
    }*/

    //Creates a new audio source and plays an audio clip.
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
}