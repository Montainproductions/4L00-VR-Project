using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Schema;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sc_ScizophreniaR2 : MonoBehaviour
{
    public static Sc_ScizophreniaR2 Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced

    [Header("Falling Object")]
    [SerializeField]
    private Rigidbody mug;
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

    [SerializeField] private GameObject firePartciles;

    private Vector3 originalMugLocation;
    private bool mugHasNotHitFloor = true;

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
        originalMugLocation = mug.gameObject.transform.position;
        StartCoroutine(Phase3());
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
        Debug.Log("Phase1 has started");
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
                scizoRoomPhase1SudioSources[i].audioSource.clip = scizoRoomPhase1SudioSources[i].audioClip;
                scizoRoomPhase1SudioSources[i].audioSource.Play();

                Debug.Log(scizoRoomPhase1SudioSources[i].audioSource.name + " is playing");

                if (scizoRoomPhase1SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.Radio)
                {
                    continue;
                }

                while (scizoRoomPhase1SudioSources[i].audioSource.isPlaying)
                {
                    yield return null;
                }
            }

            Phase1isPlaying = false;
        }

        Debug.Log("Phase1 has ended");
        StartCoroutine(Phase2());
    }

    IEnumerator Phase2()
    {
        Debug.Log("Phase2 has started");
        bool phase2IsPlaying = true;
        float counter = 0f;
        float duration = 10f;

        while (phase2IsPlaying)
        {
            counter += Time.deltaTime;

            float newPositionZ = Mathf.Lerp(5f, -5f, counter / duration);
            shadowsGroupTransform.position = new Vector3(shadowsGroupTransform.position.x, shadowsGroupTransform.position.y, newPositionZ);

            float newScaleY = Mathf.Lerp(1f, 5f, counter / duration);
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

        Debug.Log("Phase3 has started");
        float timer = 0f;
        float duration = 10f;
        bool phase3IsPlaying = true;
        scizoRoomPhase1SudioSources[2].audioSource.Stop();

        while (phase3IsPlaying)
        {
            

            while (mugHasNotHitFloor)
            {

                /*Vector3 dir = (mug.gameObject.transform.position - mugLocations[1].transform.position).normalized;
                float power = 0.5f;
                mug.AddForce(-dir * power, ForceMode.Force);*/

                /*float positionZ = Mathf.Lerp(mug.gameObject.transform.position.z, mugLocations[0].transform.position.z, timer / duration);
                timer += Time.deltaTime;
                mug.gameObject.transform.position = new Vector3(mug.gameObject.transform.position.x, mug.gameObject.transform.position.y, positionZ);*/

                mug.gameObject.transform.position = Vector3.MoveTowards(mug.gameObject.transform.position, mugLocations[0].transform.position, 0.1f * Time.deltaTime);

                yield return null;
            }

            /*if (timer >= duration)
            {
                Debug.Log("Phase3 has ended");
                phase3IsPlaying = false;
                StartCoroutine(Phase4());
            }*/

            if (mugHasNotHitFloor == false)
            {
                /*mug.velocity = new Vector3(0,0,0);
                mug.gameObject.transform.position = originalMugLocation;
                mug.gameObject.transform.rotation = Quaternion.identity;*/
                for (int i = 0; i < scizoRoomPhase3SudioSources.Length; i++)
                {

                    Debug.Log(timer);
                    if (timer > 1f)
                    {
                        mug.velocity = new Vector3(0, 0, 0);
                        mug.gameObject.transform.rotation = Quaternion.identity;
                        mug.gameObject.transform.position = originalMugLocation;
                        mug.velocity = new Vector3(0, 0, 0);
                    }

                    scizoRoomPhase3SudioSources[i].audioSource.clip = scizoRoomPhase3SudioSources[i].audioClip;
                    scizoRoomPhase3SudioSources[i].audioSource.Play();

                    Debug.Log(scizoRoomPhase3SudioSources[i].audioSource.name + " is playing");

                    while (scizoRoomPhase3SudioSources[i].audioSource.isPlaying)
                    {
                        timer += Time.deltaTime;
                        yield return null;
                    }
                    yield return null;
                }
                phase3IsPlaying = false;
            }
            
        }
        StartCoroutine(Phase4());
    }

    IEnumerator Phase4()
    {
        Debug.Log("Phase4 has started");
        bool phase4IsPlaying = true;

        firePartciles.SetActive(true);

        while (phase4IsPlaying)
        {
            for (int i = 0; i < scizoRoomPhase3SudioSources.Length; i++)
            {
                scizoRoomPhase4SudioSources[i].audioSource.clip = scizoRoomPhase4SudioSources[i].audioClip;
                scizoRoomPhase4SudioSources[i].audioSource.Play();

                Debug.Log(scizoRoomPhase4SudioSources[i].audioSource.name + " is playing");

                if (scizoRoomPhase4SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.FireAlarm)
                {
                    continue;
                }

                while (scizoRoomPhase4SudioSources[i].audioSource.isPlaying)
                {
                    yield return null;
                }
                yield return null;
            }
            phase4IsPlaying = false;
        }
        yield return null;
        Debug.Log("Phase4 has ended");
    }

    public void BeginPhaseOne()
    {
        StartCoroutine(Phase1());
    }

    public void MugHitFool()
    {
        Debug.Log("Mug has hit the floor");
        mugHasNotHitFloor = false;
    }
}

[System.Serializable]
public class ScizoRoomAudioData
{
    public AudioSource audioSource;
    public AudioClip audioClip;
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
