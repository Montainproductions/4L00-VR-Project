using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PanicDisorderR1 : MonoBehaviour
{
    public static Sc_PanicDisorderR1 Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced

    //The pause menu and maingame UI objects
    public GameObject pauseMenu, mainMenu;

    //The text UIs that appear through out the stages
    [SerializeField]
    private GameObject[] textUI;

    [Header("Ceiling")]
    //Objects for the ceiling and thee final position
    [SerializeField]
    private GameObject ceiling, finalPos;
    //The speed that the ceiling will go down at
    [SerializeField]
    private float speed;
    private bool lowerCeiling;

    [Header("Lights")]
    // Collect an Array of lights to be changed
    [SerializeField]
    private Light[] lights;
    // Change the light's intensity to the given value
    [SerializeField]
    private float intensityChangeTo = 1f;
    //For how long the lights will change
    [SerializeField]
    private float duration = 2f;

    // If we want to make the light's change gradually instead
    [Header("Lights Additonal Options")]
    [SerializeField]
    private bool gradualChange;

    [SerializeField]
    private BlurEffect effectBlur;
    [SerializeField]
    private float newFocalLength, durationFOV;


    [Header("Highlighting")]
    //The shading that the objects will have
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
        lowerCeiling = false;
        //Sets all of the texts to inactive
        StartCoroutine(DeactivateUI());
        //Starts the first phase of the room
        StartCoroutine(Phase1(20));
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        //Lowers the ceiling
        if (lowerCeiling)
        {
            Debug.Log("Wall falling");
            ceiling.transform.position = Vector3.MoveTowards(ceiling.transform.position, finalPos.transform.position, speed * Time.deltaTime); //Slowly moves the wall from where it is to its final destination
        }
    }

    //Starts highLighting object
    public void StartObjectHighLighting()
    {
        listOfHighlightingObjects[panicRoomState].StartHighlighting();
    }

    //Stops highLighting object
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

    //Changes lights on/off
    public void TurnOnOffLights()
    {
        Debug.Log("LightSwitch Working");
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = !lights[i].enabled;
        }
    }

    //Sets all UI to inactive
    IEnumerator DeactivateUI()
    {
        for(int i = 0; i < textUI.Length; i++)
        {
            textUI[i].SetActive(false);
        }
        yield return null;
    }

    //Phase 1 of panic room
    IEnumerator Phase1(float timeDelay)
    {
        Debug.Log("Phase 1 starting");
        //Plays the first two audios using the first two sources that are in the correct position 
        Sc_AudioManager.Instance.PlayAudio(0, 0);
        Sc_AudioManager.Instance.PlayAudio(1, 1);
        //Wait for a time delay of 10 seconds
        yield return new WaitForSeconds(10);
        //Activates the first UI text
        textUI[0].SetActive(true);
        yield return new WaitForSeconds(2);
        Sc_AudioManager.Instance.PlayAudio(5, 10);
        //Waits for the time given from the parameter
        yield return new WaitForSeconds(timeDelay);
        //Starts lowering the ceiling
        lowerCeiling = true;
        //Deactivates the first UI text and activates the second UI text
        textUI[0].SetActive(false);
        textUI[1].SetActive(true);
        //Waits to play VA - Two Seconds
        yield return new WaitForSeconds(2);
        Sc_AudioManager.Instance.PlayAudio(6, 7);
        //Waits to play VA - Two Seconds
        yield return new WaitForSeconds(2);
        Sc_AudioManager.Instance.PlayAudio(7, 6);
        //Finishes the coroutine
        yield return null;
    }

    //Phase 2 of the panic room
    public IEnumerator Phase2(float timeDelay)
    {
        //Check if we want to change the light's gradually
        if (gradualChange)
        {
            // The fade function requires the array of lights, the intensity we want to change to, and the time it'll take to change the intensity
            StartCoroutine(Fade(lights, intensityChangeTo, duration));
            //Debug.Log("Lights changing");
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
        //Plays the third audio clip using the third audio source
        Sc_AudioManager.Instance.PlayAudio(3, 3);
        //Increases the audio of the audio mixer
        Sc_AudioManager.Instance.ChangeAudioMixer();
        //Wait for the time delay given in the parameter to finish
        yield return new WaitForSeconds(timeDelay);
        //Starts the third corutine.
        StartCoroutine(Phase3(timeDelay));
        //Finishes the corutine
        yield return null;
    }


    IEnumerator Phase3(float timeDelay)
    {
        Debug.Log("Phase 3 Starting");
        //Wait for 2 seconds for the timer to finish
        yield return new WaitForSeconds(timeDelay);
        //Plays the figth audio clip using the third audio source
        Sc_AudioManager.Instance.PlayAudio(3, 5);
        Sc_AudioManager.Instance.PlayAudio(4, 13);
        effectBlur.ChangeBlur(newFocalLength, durationFOV);
        textUI[1].SetActive(false);
        textUI[2].SetActive(true);
        //Waits to play VA - Five Seconds
        yield return new WaitForSeconds(5);
        Sc_AudioManager.Instance.PlayAudio(5, 14);
        //Waits to play VA - Three Seconds
        yield return new WaitForSeconds(3);
        Sc_AudioManager.Instance.PlayAudio(6, 15);
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
