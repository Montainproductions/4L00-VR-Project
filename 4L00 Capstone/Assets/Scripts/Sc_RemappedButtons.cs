using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Sc_RemappedButtons : MonoBehaviour
{
    private XRIDefaultInputActions playerInputActions;

    [SerializeField]
    private GameObject mainCamera;

    private Sc_UIManager uiManager;

    [Header("UI")]
    [SerializeField]
    private Camera eventCamera;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private bool canPause = false;
    [SerializeField]
    private bool pauseMenuCopingRoom;

    private bool paused = false;
    private GameObject menuObject = null;

    public void Awake()
    {
        playerInputActions = new XRIDefaultInputActions();
        playerInputActions.XRILeftHandInteraction.Enable();      
        playerInputActions.XRILeftHandInteraction.YX.performed += CalmingRoom_Preformed;
        playerInputActions.XRIRightHandInteraction.Enable();
        playerInputActions.XRIRightHandInteraction.UIActivation.performed += UIActivation_Performed;
    }

    private void CalmingRoom_Preformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Sc_GameManager.Instance.currentLevel != 4)
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                Sc_GameManager.Instance.CopingRoom();
            }else if (Sc_GameManager.Instance.currentLevel == 4)
            {
                Sc_GameManager.Instance.GoToLevel(1);
            }
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    private void UIActivation_Performed(InputAction.CallbackContext context)
    {
        if (!context.performed || !canPause) return;
        if (!paused)
        {
            UISpawning();
        }
        else
        {
            UIStopSpawning();
        }
    }

    public void UISpawning()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 cameraDirection = mainCamera.transform.forward;
        Vector3 canvasSpawnPosition = cameraPosition + cameraDirection * 5;
        Debug.Log(canvasSpawnPosition);
        GameObject menu = Instantiate(pauseMenu, canvasSpawnPosition, mainCamera.transform.rotation);
        menu.transform.rotation = Quaternion.Euler(0f, menu.transform.localEulerAngles.y, 0f);

        menuObject = menu;
            Canvas menuCanvas = menu.GetComponent<Canvas>();
            menuCanvas.worldCamera = eventCamera;
            uiManager = menu.GetComponent<Sc_UIManager>();
            if (pauseMenuCopingRoom)
            {
                StartCoroutine(uiManager.PauseMenuCoping());
            }
            else
            {
                StartCoroutine(uiManager.PauseMenuAtrium());
            }

            Time.timeScale = 0;
            AudioListener.pause = true;
            paused = true;
    }

    public void UIStopSpawning()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        if (pauseMenuCopingRoom)
        {
            StartCoroutine(uiManager.PauseMenuCoping());
        }
        else
        {
            StartCoroutine(uiManager.PauseMenuAtrium());
        }
        DestroyMenu();
    }

    public void DestroyMenu()
    {
        Destroy(menuObject);
        menuObject= null;
        paused = false;
    }
}
