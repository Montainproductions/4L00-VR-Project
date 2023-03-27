using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Sc_RemappedButtons : MonoBehaviour
{
    private XRIDefaultInputActions playerInputActions;

    [SerializeField]
    private Sc_GameManager gameManager;

    [SerializeField]
    private Sc_UIManager uiManager;

    [SerializeField]
    private GameObject mainGameUI, pauseMenuUI;

    public void Awake()
    {
        playerInputActions = new XRIDefaultInputActions();
        playerInputActions.XRILeftHandInteraction.Enable();      
        playerInputActions.XRILeftHandInteraction.YX.performed += CalmingRoom_Preformed;
        playerInputActions.XRIRightHandInteraction.Enable();
        playerInputActions.XRIRightHandInteraction.UIActivation.performed += UIActivation_Performed;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameManager.currentLevel);
    }

    private void CalmingRoom_Preformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (gameManager.currentLevel != 4)
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                gameManager.CopingRoom();
            }else if (gameManager.currentLevel == 4)
            {
                gameManager.GoToLevel(1);
            }
        }
    }

    private void UIActivation_Performed(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        int level = gameManager.currentLevel;
        //Debug.Log(level);
        if (level != 6)
        {
            Debug.Log("Pausing UI");
            uiManager.ToPauseMenuGame();
        }
    }
}
