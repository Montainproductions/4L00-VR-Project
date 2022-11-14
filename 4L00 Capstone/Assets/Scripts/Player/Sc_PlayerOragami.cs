using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_PlayerOragami : MonoBehaviour{
    private GameObject outView, inView;
    private bool askToView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if(askToView){
            gameObject.transform = inView.transform;
        }
        else
        {
            gameObject.transform = outView.transform;
        }
    }
}
