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
        audioSources[1].Play();
        yield return null;
    }

    IEnumerator Phase4()
    {
        audioSources[2].Play();
        yield return null;
    }
}
