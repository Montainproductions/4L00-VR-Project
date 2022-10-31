using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Settings : MonoBehaviour
{
    public GameObject currentSettings, returningthing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        returningthing.SetActive(true);
        currentSettings.SetActive(false);
    }
}
