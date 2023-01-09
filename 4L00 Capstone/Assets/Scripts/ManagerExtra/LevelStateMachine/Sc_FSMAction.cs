using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sc_FSMAction : ScriptableObject{
    public abstract void Execute(Sc_LevelStateMachine stateMachine);
}
