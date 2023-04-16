using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_UIManager : MonoBehaviour{
    [SerializeField]
    private GameObject pauseMenuCoping, pauseMenuAtrium;
    private bool pauseMenuActiveCoping, pauseMenuActiveAtrium;
    
    private GameObject player;
    private Sc_RemappedButtons remappedButton;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        remappedButton = player.GetComponent<Sc_RemappedButtons>();
    }

    public void Start()
    {
        pauseMenuActiveCoping = false;
        pauseMenuActiveAtrium = false;
    }

    public void PauseMenuDeactivate()
    {
        remappedButton.UIStopSpawning();
    }

    public IEnumerator PauseMenuCoping()
    {
        pauseMenuActiveCoping = !pauseMenuActiveCoping;
        pauseMenuCoping.SetActive(pauseMenuActiveCoping);
        pauseMenuActiveAtrium = false;
        yield return null;
    }
    public IEnumerator PauseMenuAtrium()
    {
        pauseMenuActiveCoping = false;
        pauseMenuActiveAtrium = !pauseMenuActiveAtrium;
        pauseMenuAtrium.SetActive(pauseMenuActiveAtrium);
        yield return null;
    }
}