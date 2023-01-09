using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public class Sc_Transition : ScriptableObject{
    public Sc_Decision Decision;
    public Sc_BaseLevel TrueState;
    public Sc_BaseLevel FalseState;

    public void Execute(Sc_LevelStateMachine stateMachine){
        if (Decision.Decide(stateMachine) && !(TrueState is Sc_RemainInState)){
            stateMachine.CurrentState = TrueState;
        }else if (!(FalseState is Sc_RemainInState)){
            stateMachine.CurrentState = FalseState;
        }
    }
}
