using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sc_UIManager : MonoBehaviour{
    [SerializeField]
    private bool inMainMenu;

    [SerializeField]
    private GameObject mainGame, pauseMenuCoping, pauseMenuAtrium;
    [SerializeField]
    private bool  mainGameActive, pauseMenuActiveCoping, pauseMenuActiveAtrium;

    public void Awake()
    {
    }

    public void Start()
    {
        //if (pauseMenuActiveAtrium || pauseMenuActiveCoping) return;
        if (inMainMenu)
        {
            mainGameActive = false;
        }
        else
        {
            mainGameActive = true;
        }
        pauseMenuActiveCoping = false;
        pauseMenuActiveAtrium = false;
    }

    public void Update()
    {
        mainGame.SetActive(mainGameActive);
        pauseMenuCoping.SetActive(pauseMenuActiveCoping);
        pauseMenuAtrium.SetActive(pauseMenuActiveAtrium);
    }

    public IEnumerator PauseMenuCoping()
    {
        /*Debug.Log("Pausing UI");
        mainGameActive = !mainGameActive;
        pauseMenuActiveCoping = !pauseMenuActiveCoping;*/
        yield return new WaitForSeconds(0.1f);
        mainGameActive = !mainGameActive;
        pauseMenuActiveCoping = !pauseMenuActiveCoping;
        pauseMenuActiveAtrium = false;
        yield return null;
    }
    public IEnumerator PauseMenuAtrium()
    {
        yield return new WaitForSeconds(0.1f);
        mainGameActive = !mainGameActive;
        pauseMenuActiveCoping = false;
        pauseMenuActiveAtrium = !pauseMenuActiveAtrium;
        Debug.Log(mainGameActive);
        Debug.Log(pauseMenuActiveAtrium);
        yield return null;
    }
}