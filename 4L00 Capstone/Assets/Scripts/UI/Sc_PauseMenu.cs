using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, mainGame, settings, controls;
    public Button buttonCopingRoom, buttonControls, buttonSettings, buttonReturn;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonCopingRoom.onClick.AddListener(() =>
        {
            Sc_GameManager.Instance.GoToLevel(Sc_GameManager.Instance.SRSceneNumber);
            //Sc_LevelManager.Instance.GoToCopingRoom();
        });

        buttonControls.onClick.AddListener(() =>
        {
            controls.SetActive(true);
            pauseMenu.SetActive(false);
        });

        buttonSettings.onClick.AddListener(() =>
        {
            settings.SetActive(true);
            pauseMenu.SetActive(false);
        });

        buttonReturn.onClick.AddListener(() =>
        {
            mainGame.SetActive(true);
            FPS_PlayerMovement.Instance.LockMouse();
            pauseMenu.SetActive(false);
        });
    }
}
