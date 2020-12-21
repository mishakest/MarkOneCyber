using UnityEngine;

public class SlideState : MoveState
{
    public SlideState(Actor actor, ActorData data, StateMachine stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Slide State");

        actor.InputHandler.UseSlideInput();
        actor.Collider.SetColliderHeight(data.SlideColliderHeight);
    }

    public override void Tick()
    {
        base.Tick();

        if (Time.time >= startTime + data.MaxSlideTime)
        {
            stateMachine.ChangeState(actor.RunState);
        }
        else if (jumpInput && isTouchingGround)
        {
            stateMachine.ChangeState(actor.JumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        Debug.Log("Exit Slide State");

        actor.Collider.SetColliderHeight(data.StandColliderHeight);
    }
}