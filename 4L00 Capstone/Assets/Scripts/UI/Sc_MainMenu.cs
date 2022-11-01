using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sc_MainMenu : MonoBehaviour
{
    public GameObject mainMenu, settings;
    public Button startGameButton, settingButton, quitButton;

    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(() =>
        {
            Sc_GameManager.Instance.GoToLevel(1);
        });

        settingButton.onClick.AddListener(() =>
        {
            settings.SetActive(true);
            mainMenu.SetActive(false);
        });

        quitButton.onClick.AddListener(() =>
        {
            Debug.Log("Quiting");
            Application.Quit();
        });
    }
}
