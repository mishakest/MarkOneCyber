using UnityEngine;

public class RunState : MoveState
{
    public RunState(Actor actor, ActorData data, StateMachineOld stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }

    public override void Tick()
    {
        base.Tick();

        if (jumpInput && isTouchingGround)
        {
            stateMachine.ChangeState(actor.JumpState);
        }
        else if (slideInput)
        {
            stateMachine.ChangeState(actor.SlideState);
        }
    }
}
