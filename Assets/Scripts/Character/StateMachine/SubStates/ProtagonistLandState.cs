using MarkOne.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistLandState : ProtagonistMoveState
{
    public ProtagonistLandState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        if (actor.IsAnimationEnded)
        {
            actor.UseAnimation();
            stateMachine.ChangeState(actor.StatesTable.RunState);
        }
        else if (actor.JumpInput)
        {
            actor.UseJumpInput();
            stateMachine.ChangeState(actor.StatesTable.JumpState);
        }
        else if (actor.SlideInput)
        {
            actor.UseSlideInput();
            stateMachine.ChangeState(actor.StatesTable.SlideState);
        }
    }
}
