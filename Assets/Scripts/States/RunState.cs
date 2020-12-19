using UnityEngine;

public class RunState : MoveState
{
    public override void Tick()
    {
        base.Tick();

        if (actor.InputHandler.JumpInput && isTouchingGround)
        {
            stateMachine.ChangeState(actor.JumpState);
        }
        else if (actor.InputHandler.SlideInput)
        {
            stateMachine.ChangeState(actor.SlideState);
        }
    }
}
