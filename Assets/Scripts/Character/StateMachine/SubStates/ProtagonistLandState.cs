using MarkOne.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistLandState : ProtagonistMoveState
{
    public ProtagonistLandState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }
}
