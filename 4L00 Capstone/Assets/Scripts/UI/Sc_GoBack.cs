using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GoBack : MonoBehaviour
{
    public GameObject currentSettings, returningthing;

    public void Return()
    {
        returningthing.SetActive(true);
        currentSettings.SetActive(false);
    }
}
