using MarkOne.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class ProtagonistSlideState : ProtagonistMoveState
{
    public ProtagonistSlideState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        if (!isGrounded)
            GoToTheGround();

        actor.Collider.SetColliderHeight(actor.Data.SlideCollierHeight);
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        if (Time.time >= stateEnterTime + actor.Data.SlideTime)
        {
            stateMachine.ChangeState(actor.StatesTable.RunState);
        }
        else if (actor.JumpInput && isGrounded)
        {
            actor.UseJumpInput();
            stateMachine.ChangeState(actor.StatesTable.JumpState);
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();

        actor.Collider.SetColliderHeight(actor.Data.StayColliderHeight);
    }

    //todo: change method name
    private void GoToTheGround()
    {
        var velocity = actor.Rigidbody.velocity;
        actor.Rigidbody.velocity = new Vector3(0.0f, -actor.Data.JumpToSlideForce, 0.0f);
    }
}
