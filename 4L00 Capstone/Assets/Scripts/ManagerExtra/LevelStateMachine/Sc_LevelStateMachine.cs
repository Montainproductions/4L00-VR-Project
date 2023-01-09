using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_LevelStateMachine : MonoBehaviour{
    [SerializeField]
    private Sc_BaseLevel _initialState;

    public Sc_BaseLevel CurrentState { get; set; }

    private void Awake(){
        CurrentState = _initialState;
    }

    private void Update(){
        CurrentState.Execute(this);
    }
}
