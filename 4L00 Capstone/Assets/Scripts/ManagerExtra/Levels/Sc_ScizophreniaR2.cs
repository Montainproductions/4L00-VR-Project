using System.Collections;
using System.Collections.Generic;
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
}
