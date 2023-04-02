using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_UIManager : MonoBehaviour{
    [SerializeField]
    private bool inMainMenu;

    [SerializeField]
    private GameObject mainMenu, mainGame, pauseMenuCoping, pauseMenuAtrium;
    [SerializeField]
    private bool mainMenuActive, mainGameActive, pauseMenuActiveCoping, pauseMenuActiveAtrium;

    public void Awake()
    {
    }

    public void Start()
    {
        if (pauseMenuActiveAtrium || pauseMenuActiveCoping) return;
        if (inMainMenu)
        {
            mainMenuActive = true;
            mainGameActive = false;
            pauseMenuActiveCoping = false;
        }
        else
        {
            mainMenuActive = false;
            mainGameActive = true;
            pauseMenuActiveCoping = false;
            pauseMenuActiveAtrium = false;
        }
    }

    public void Update()
    {
        mainMenu.SetActive(mainMenuActive);
        mainGame.SetActive(mainGameActive);
        pauseMenuCoping.SetActive(pauseMenuActiveCoping);
        pauseMenuAtrium.SetActive(pauseMenuActiveAtrium);
    }

    public void PauseMenuCoping()
    {
        /*Debug.Log("Pausing UI");
        mainGameActive = !mainGameActive;
        pauseMenuActiveCoping = !pauseMenuActiveCoping;*/
        mainMenuActive = false;
        mainGameActive = false;
        pauseMenuActiveCoping = true;
        pauseMenuActiveAtrium = false;
    }
    public void PauseMenuAtrium()
    {
        mainMenuActive = false;
        mainGameActive = false;
        pauseMenuActiveCoping = false;
        pauseMenuActiveAtrium = true;
    }

}
