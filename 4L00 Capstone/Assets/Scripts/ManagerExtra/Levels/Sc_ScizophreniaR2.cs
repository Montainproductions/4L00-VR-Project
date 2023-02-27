using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    private ScizoRoomAudioData[] scizoRoomPhase1SudioSources;
    [SerializeField]
    private ScizoRoomAudioData[] scizoRoomPhase2SudioSources;
    [SerializeField]
    private ScizoRoomAudioData[] scizoRoomPhase3SudioSources;
    [SerializeField]
    private ScizoRoomAudioData[] scizoRoomPhase4SudioSources;

    [Header("Shadow Objects")]
    [SerializeField] private Transform shadowsGroupTransform;

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
        //scizoRoomPhase1SudioSources[1].audioToBePlayed = ScizoRoomAudioData.AudioToBePlayed.BossLine1;

        //BeginPhaseOne();
        StartCoroutine(Phase2());
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
        bool Phase1isPlaying = true;
        AudioSource bossLineOne = null;
        AudioSource bossLineTwo = null;
        AudioSource bossLineThree = null;
        AudioSource radio = null;

        for (int i = 0; i < scizoRoomPhase1SudioSources.Length; i++)
        {
            if (scizoRoomPhase1SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.BossLine1)
            {
                bossLineOne = scizoRoomPhase1SudioSources[i].audioSource;
            }
            else if (scizoRoomPhase1SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.BossLine2)
            {
                bossLineTwo = scizoRoomPhase1SudioSources[i].audioSource;
            }
            else if (scizoRoomPhase1SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.BossLine3)
            {
                bossLineThree = scizoRoomPhase1SudioSources[i].audioSource;
            }
            else if (scizoRoomPhase1SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.Radio)
            {
                radio = scizoRoomPhase1SudioSources[i].audioSource;
            }
        }

        while(Phase1isPlaying)
        {
            for (int i = 0; i < scizoRoomPhase1SudioSources.Length; i++)
            {
                scizoRoomPhase1SudioSources[i].audioSource.Play();

                Debug.Log(scizoRoomPhase1SudioSources[i].audioSource.name + " is playing");

                while (scizoRoomPhase1SudioSources[i].audioSource.isPlaying)
                {
                    yield return null;
                }
            }

            Phase1isPlaying = false;
        }

        StartCoroutine(Phase2());
    }

    IEnumerator Phase2()
    {
        bool phase2IsPlaying = true;
        float counter = 0f;
        float duration = 10f;

        while (phase2IsPlaying)
        {
            Debug.Log("Phase2 is playing");
            counter += Time.deltaTime;

            float newPositionX = Mathf.Lerp(5f, -5f, counter / duration);
            shadowsGroupTransform.position = new Vector3(newPositionX, shadowsGroupTransform.position.y, shadowsGroupTransform.position.z);

            float newScaleY = Mathf.Lerp(1f, 10f, counter / duration);
            shadowsGroupTransform.localScale = new Vector3(shadowsGroupTransform.localScale.x, newScaleY, shadowsGroupTransform.localScale.z);

            if(counter >= duration)
            {
                Debug.Log("Phase2 has ended");
                phase2IsPlaying = false;
            }
            yield return null;
        }

        StartCoroutine(Phase3());
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
