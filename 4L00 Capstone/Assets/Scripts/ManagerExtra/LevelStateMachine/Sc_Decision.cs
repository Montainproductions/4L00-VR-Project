using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sc_Decision : ScriptableObject{
    public abstract bool Decide(Sc_LevelStateMachine state);
}
