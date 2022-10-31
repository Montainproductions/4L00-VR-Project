using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sc_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, mainGame, settings, controls;
    public Button buttonReturn, buttonControls, buttonSettings, buttonCopingRoom;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonControls.onClick.AddListener(() =>
        {
            controls.SetActive(true);
            pauseMenu.SetActive(false);
        });

        buttonReturn.onClick.AddListener(() =>
        {
            mainGame.SetActive(true);
            pauseMenu.SetActive(false);
        });

        buttonSettings.onClick.AddListener(() =>
        {
            settings.SetActive(true);
            pauseMenu.SetActive(false);
        });

        buttonCopingRoom.onClick.AddListener(() =>
        {
            Sc_LevelManager.Instance.SafeRoom();
            //Sc_LevelManager.Instance.GoToCopingRoom();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCopingRoom()
    {
        //Sc_LevelManager.Instance.GoToCopingRoom();
    }

    /*public void GoToControls()
    {
        controls.SetActive(true);
        pauseMenu.SetActive(false);
    }*/

    /*public void GoToSettings()
    {
        settings.SetActive(true);
        pauseMenu.SetActive(false);
    }*/

    /*public void GoBack()
    {
        mainGame.SetActive(true);
        pauseMenu.SetActive(false);
    }*/
}
