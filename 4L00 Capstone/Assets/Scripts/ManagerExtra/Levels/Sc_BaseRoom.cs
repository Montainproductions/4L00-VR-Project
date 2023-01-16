using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_BaseRoom : MonoBehaviour
{
    public static Sc_BaseRoom Instance { get; private set; } //Singleton of the script/gameobject so that it can be referenced

    public GameObject pauseMenu, mainMenu;

    [SerializeField]
    private int SRSceneNumber;

    [SerializeField]
    private GameObject[] textUI;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }
}
