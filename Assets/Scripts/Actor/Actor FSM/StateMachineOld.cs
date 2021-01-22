using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineOld
{
    public State CurrentState { get; private set; }

    public void Init(State startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
