using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_UIReturn : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset ActionAsset;

    [SerializeField]
    private InputActionReference JoyStitckR;

    [SerializeField]
    private bool inMainMenu;

    Gamepad gamepad;
    [SerializeField]
    private GameObject mainMenu, mainGame, pauseMenu;
    private bool mainMenuActive, mainGameActive, pauseMenuActive;

    public void Awake()
    {
        gamepad = Gamepad.current;
        JoyStitckR.action.performed += Pause_performed;
    }

    public void Start()
    {
        if (inMainMenu)
        {
            mainMenuActive = true;
            pauseMenuActive = false;
        }
        else
        {
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

    public void ToPauseMenu()
    {
        mainMenuActive = !mainMenuActive;
        pauseMenuActive = !pauseMenuActive;
    }

    public void PrintClick()
    {
        Debug.Log("To main game");
    }

    private void Pause_performed(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Debug.Log("Pause Menu");
        ToPauseMenu();
    }

    public void OnDestroy()
    {
        JoyStitckR.action.performed -= Pause_performed;
    }
}
