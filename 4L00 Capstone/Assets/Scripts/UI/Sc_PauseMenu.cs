using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu,mainGame, settings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCopingRoom()
    {
        //Sc_LevelManager.Instance.GoToCopingRoom();
    }

    public void GoToSettings()
    {
        settings.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void GoBack()
    {
        mainGame.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
