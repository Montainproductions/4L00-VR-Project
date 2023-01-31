using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Sc_ScizophreniaR2 : MonoBehaviour
{
    public static Sc_ScizophreniaR2 Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced

    [Header("Falling Object")]
    [SerializeField]
    private GameObject mug;
    [SerializeField]
    private GameObject[] mugLocations;
    [SerializeField]
    private float speed;

    [Header("Sound")]
    [SerializeField]
    private AudioSource[] audioSources;
    [SerializeField]
    private ScizoRoomAudioData[] scizoRoomSudioSources;

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
        scizoRoomSudioSources[1].audioToBePlayed = ScizoRoomAudioData.AudioToBePlayed.BossLine1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InitalPhase()
    {
        yield return null;
    }

    IEnumerator Phase1()
    {
        float timer = 15f;
        AudioSource bossLineOne;
        AudioSource bossLineTwo;
        AudioSource bossLineThree;
        AudioSource radio;

        timer -= Time.deltaTime;

        for(int i = 0; i < scizoRoomSudioSources.Length; i++)
        {
            if (scizoRoomSudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.BossLine1)
            {
                bossLineOne = scizoRoomSudioSources[i].audioSource;
            }
            else if (scizoRoomSudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.BossLine2)
            {
                bossLineTwo = scizoRoomSudioSources[i].audioSource;
            }
            else if (scizoRoomSudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.BossLine3)
            {
                bossLineThree = scizoRoomSudioSources[i].audioSource;
            }
            else if (scizoRoomSudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.Radio)
            {
                radio = scizoRoomSudioSources[i].audioSource;
            }
        }

        if (timer <= 0)
        {
            StartCoroutine(Phase2());
        }
        audioSources[0].Play();
        yield return null;
    }

    IEnumerator Phase2()
    {
        yield return null;
    }

    IEnumerator Phase3()
    {
        /*audioSources[0].Stop();
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange); //Slowly increase current velocity in the x direction untill max is reached
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange); //Slowly increase current velocity in the z direction untill max is reached
        Vector3 displacement = velocity * Time.deltaTime; //Distance the player will be moved by
        //transform.position += displacement;

        movement = transform.right * displacement.x + transform.up * displacement.y + transform.forward * displacement.z; //Distance moved depending on world vectors
        transform.position += movement; //Move character
        audioSources[1].Play();
        */
        yield return null;
    }

    IEnumerator Phase4()
    {
        audioSources[2].Play();
        yield return null;
    }

    public void BeginPhaseOne()
    {
        StartCoroutine(Phase1());
    }
}

[System.Serializable]
public class ScizoRoomAudioData
{
    public AudioSource audioSource;
    public enum AudioToBePlayed
    {
        BossLine1,
        BossLine2,
        BossLine3,
        InnerVoiceLine1,
        InnerVoiceLine2,
        InnerVoiceLine3,
        InnerVoiceLine4,
        InnerVoiceLine5,
        InnerVoiceLine6,
        InnerVoiceLine7,
        InnerVoiceLine8,
        InnerVoiceLine9,
        Radio,
        FireAlarm,
        FireSound
    }

    public AudioToBePlayed audioToBePlayed;
}
