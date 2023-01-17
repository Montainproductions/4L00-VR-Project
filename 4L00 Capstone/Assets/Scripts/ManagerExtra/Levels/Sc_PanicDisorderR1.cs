using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PanicDisorderR1 : MonoBehaviour
{
    public static Sc_PanicDisorderR1 Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced

    public GameObject pauseMenu, mainMenu;

    [SerializeField]
    private int SRSceneNumber;

    [SerializeField]
    private GameObject[] textUI;

    [SerializeField]
    private GameObject ceiling, finalPos;
    [SerializeField]
    private float speed;

    [Header("Lights")]
    // Collect an Array of lights to be changed
    [SerializeField]
    private Light[] lights;
    // Change the light's intensity to the given value
    [SerializeField]
    private float intensityChangeTo = 1f;
    [SerializeField]
    private float duration = 2f;

    // If we want to make the light's change gradually instead
    [Header("Lights Additonal Options")]
    [SerializeField]
    private bool gradualChange;

    [SerializeField]
    private ShaderEditing[] listOfHighlightingObjects;
    private int panicRoomState;

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

    public void Start()
    {
        panicRoomState = 0;

        StartCoroutine(Phase1(20));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            mainMenu.SetActive(false);
        }


    }

    public void StartObjectHighLighting()
    {
        listOfHighlightingObjects[panicRoomState].StartHighlighting();
    }

    public void StopObjectHighLighting()
    {
        foreach (var highlightingObject in listOfHighlightingObjects)
        {
            highlightingObject.StopHighlighting();
        }
    }

    public void IncreasePanicRoomState(int stateNumber)
    {
        panicRoomState = stateNumber;
    }

    public void TurnOnOffLights()
    {
        Debug.Log("LightSwitch Working");
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = !lights[i].enabled;

        }
    }

    IEnumerator Phase1(float timeDelay)
    {
        Debug.Log("Phase 1 starting");
        yield return new WaitForSeconds(timeDelay);
        ceiling.transform.position = Vector3.MoveTowards(ceiling.transform.position, finalPos.transform.position, speed * Time.deltaTime); //Slowly moves the wall from where it is to its final destination
        yield return null;
    }

    public IEnumerator Phase2(float timeDelay)
    {
        Debug.Log("Phase 2 starting");
        // Check if we want to change the light's gradually
        if (gradualChange)
        {
            // The fade function requires the array of lights, the intensity we want to change to, and the time it'll take to change the intensity
            StartCoroutine(Fade(lights, intensityChangeTo, duration));
            Debug.Log("Lights changing");
        }
        else
        {
            // For each light in the array, change it's intensity to new value given 
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].intensity = intensityChangeTo;
                yield return null;
            }
        }

        Sc_AudioManager.Instance.ChangeAudioMixer();
        yield return new WaitForSeconds(timeDelay);
        StartCoroutine(Phase3(timeDelay));
        yield return null;
    }


    IEnumerator Phase3(float timeDelay)
    {
        Debug.Log("Phase 3 Starting");
        yield return new WaitForSeconds(2);
        Sc_AudioManager.Instance.PlayAudio[0];
        yield return null;
    }

    // Gradually Change the lights based on a given duration
    IEnumerator Fade(Light[] lightToFade, float maxLuminosity, float duration)
    {
        // our minLuminosity is set to the first light in the array (i'm assuming all the lights will be at the same intensity initally)
        // (Contact Matt if this needs to be changed)
        float minLuminosity = lightToFade[0].intensity;
        // This will count the seconds that pass
        float counter = 0f;
        // While the seconds that pass are still below the duration limit, run the rest of this code
        while (counter < duration)
        {
            // Increment the counter by real seconds
            counter += Time.deltaTime;
            // Change the each light in the array of lights
            for (int i = 0; i < lightToFade.Length; i++)
            {
                // This changes the light's intentisty to the new intentisty over a certain duration
                lightToFade[i].intensity = Mathf.Lerp(minLuminosity, maxLuminosity, counter / duration);
            }
            // IEnumerator's require a return value, but we don't need to return anything, so just pass null instead
            yield return null;
        }
    }
}
