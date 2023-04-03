using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Schema;
//using UnityEditor.TextCore.Text;
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
    [SerializeField] private GameObject exitUI;

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

    // Called by opening the email on the computer
    public void BeginPhaseOne()
    {
        StartCoroutine(Phase1());
    }

    // Phase 1 is audio sources playing
    IEnumerator Phase1()
    {
        Debug.Log("Phase1 has started");
        bool Phase1isPlaying = true;

        while(Phase1isPlaying)
        {
            // Go through each audio clip in the Phase1 array
            // The will play in order of the Array and wait until the last clip has finished before starting the next
            for (int i = 0; i < scizoRoomPhase1SudioSources.Length; i++)
            {
                // Set the audio clip for the audio source
                scizoRoomPhase1SudioSources[i].audioSource.clip = scizoRoomPhase1SudioSources[i].audioClip;
                scizoRoomPhase1SudioSources[i].audioSource.Play();

                Debug.Log(scizoRoomPhase1SudioSources[i].audioSource.name + " is playing");

                // If the audio clip is the radio then contiune immediately to the next clip
                if (scizoRoomPhase1SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.Radio)
                {
                    continue;
                }

                // Wait until the current audio is down playing before starting the next clip
                while (scizoRoomPhase1SudioSources[i].audioSource.isPlaying)
                {
                    yield return null;
                }
            }

            // Stop the Coroutine after going through all audio clips
            Phase1isPlaying = false;
        }

        Debug.Log("Phase1 has ended");
        // End of Phase 1, move to phase 2 immediately
        StartCoroutine(Phase2());
    }

    // Phase2 is Shadows moving
    IEnumerator Phase2()
    {
        Debug.Log("Phase2 has started");
        bool phase2IsPlaying = true;
        // Initialize variables
        float counter = 0f;
        float duration = 10f;

        while (phase2IsPlaying)
        {
            counter += Time.deltaTime;

            // Move the group of shadows along the z axis over time
            float newPositionZ = Mathf.Lerp(10.6f, -11f, counter / duration);
            float newPositionY = Mathf.Lerp(0.05f, 3.53f, counter / 1f);
            shadowsGroupTransform.position = new Vector3(shadowsGroupTransform.position.x, newPositionY, newPositionZ);

            // Increase the y scale of the shadows over time
            /*float newScaleY = Mathf.Lerp(1f, 5f, counter / duration);
            shadowsGroupTransform.localScale = new Vector3(shadowsGroupTransform.localScale.x, newScaleY, shadowsGroupTransform.localScale.z);*/

            // Once the timer has reached the desired duration stop Phase 2
            if(counter >= duration)
            {
                Debug.Log("Phase2 has ended");
                phase2IsPlaying = false;
            }
            yield return null;
        }

        // Start Phase 3
        StartCoroutine(Phase3());
    }

    IEnumerator Phase3()
    {
        // Old Code
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
        //float duration = 10f;
        bool phase3IsPlaying = true;

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

                // Move the mug towards the given end location over time
                mug.gameObject.transform.position = Vector3.MoveTowards(mug.gameObject.transform.position, mugLocations[0].transform.position, 0.2f * Time.deltaTime);

                yield return null;
            }

            // Not needed anymore, Phase 3 will last as long as it needs to
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
                scizoRoomPhase1SudioSources[2].audioSource.Stop();
                for (int i = 0; i < scizoRoomPhase3SudioSources.Length; i++)
                {

                    Debug.Log(timer);
                    // After 1 second move the mug back to its original position
                    if (timer > 1f)
                    {
                        //mug.velocity = new Vector3(0, 0, 0);
                        mug.gameObject.transform.rotation = Quaternion.identity;
                        mug.gameObject.transform.position = originalMugLocation;
                        //mug.velocity = new Vector3(0, 0, 0);
                    }

                    // Play Audio clips like in Phase 1
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
        // Start Phase 4
        StartCoroutine(Phase4());
    }

    IEnumerator Phase4()
    {
        Debug.Log("Phase4 has started");
        bool phase4IsPlaying = true;

        // Activate the Fire Effects
        firePartciles.SetActive(true);

        while (phase4IsPlaying)
        {
            // Just like in Phase 1 play audio sources in the order the appear in the array
            for (int i = 0; i < scizoRoomPhase3SudioSources.Length; i++)
            {
                scizoRoomPhase4SudioSources[i].audioSource.clip = scizoRoomPhase4SudioSources[i].audioClip;
                scizoRoomPhase4SudioSources[i].audioSource.Play();

                Debug.Log(scizoRoomPhase4SudioSources[i].audioSource.name + " is playing");

                // If the audio clip is the fire alarm contiune immediately onto the next audio clip
                if (scizoRoomPhase4SudioSources[i].audioToBePlayed == ScizoRoomAudioData.AudioToBePlayed.FireAlarm)
                {
                    continue;
                }

                // wait until the current audio clip is done before moving onto the next one
                while (scizoRoomPhase4SudioSources[i].audioSource.isPlaying)
                {
                    yield return null;
                }
                yield return null;
            }
            phase4IsPlaying = false;
        }
        exitUI.SetActive(true);
        yield return null;
        Debug.Log("Phase4 has ended");
        // End of Schizo Room
    }

    // Called when the mug's collider hits the ground
    public void MugHitFool()
    {
        Debug.Log("Mug has hit the floor");
        mugHasNotHitFloor = false;
    }
}

[System.Serializable]
public class ScizoRoomAudioData
{
    // Makes it easier to load both the audio source and audio clip within the same array
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Helps define whether the audio clip needs special treatment
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
