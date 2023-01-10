using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public sealed class Sc_PanicRoom : Sc_BaseLevel
{
    public List<Sc_FSMAction> Action = new List<Sc_FSMAction>();
    //public List<Transition> Transitions = new List<Transition>();

    public override void Execute(Sc_LevelStateMachine machine)
    {
        foreach (var action in Action)
            action.Execute(machine);

        //foreach (var transition in Transitions)
            //transition.Execute(machine);
    }
}
