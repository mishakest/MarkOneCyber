using MarkOne.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistInAirState : ProtagonistMoveState
{
    public ProtagonistInAirState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        if (isGrounded && actor.Rigidbody.velocity.y < 0.01f)
        {
            stateMachine.ChangeState(actor.StatesTable.RunState);
        }
        else if (actor.SlideInput)
        {
            actor.UseSlideInput();
            stateMachine.ChangeState(actor.StatesTable.SlideState);
        }
    }
}
