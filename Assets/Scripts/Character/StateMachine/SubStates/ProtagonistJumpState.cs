﻿using MarkOne.StateMachine;
using UnityEngine;

public class ProtagonistJumpState : ProtagonistMoveState
{
    public ProtagonistJumpState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        PerformJump();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        if (actor.SlideInput)
        {
            actor.UseSlideInput();
            stateMachine.ChangeState(actor.StatesTable.SlideState);
        }
        else
        {
            stateMachine.ChangeState(actor.StatesTable.InAirState);
        }
    }

    private void PerformJump()
    {
        actor.Rigidbody.velocity = new Vector3(0.0f, actor.Data.JumpForce, 0.0f);
    }
}