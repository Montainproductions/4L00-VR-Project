using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_UIManager : MonoBehaviour{
    [SerializeField]
    private bool inMainMenu;

    [SerializeField]
    private GameObject mainMenu, mainGame, pauseMenu;
    private bool mainMenuActive, mainGameActive, pauseMenuActive;

    public void Awake()
    {
    }

    public void Start()
    {
        if (inMainMenu)
        {
            mainMenuActive = true;
            mainGameActive = false;
            pauseMenuActive = false;
        }
        else
        {
            mainMenuActive = false;
            mainGameActive = true;
            pauseMenuActive = false;
        }
    }

    public void Update()
    {
        mainMenu.SetActive(mainMenuActive);
        mainGame.SetActive(mainGameActive);
        pauseMenu.SetActive(pauseMenuActive);
    }

    public void ToPauseMenuGame()
    {
        Debug.Log("Pausing UI");
        mainGameActive = !mainGameActive;
        pauseMenuActive = !pauseMenuActive;
    }

}
