using UnityEngine;

public class JumpState : MoveState
{
    public JumpState(Actor actor, ActorData data, StateMachine stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        actor.InputHandler.UseJumpInput();
        Jump();
    }

    public override void Tick()
    {
        base.Tick();

        if (isTouchingGround)
        {
            stateMachine.ChangeState(actor.RunState);
        }
        else if (actor.InputHandler.SlideInput)
        {
            stateMachine.ChangeState(actor.SlideState);
        }
    }

    private void Jump()
    {
        actor.Collider.Rigidbody.AddForce(Vector3.up * data.JumpForce, ForceMode.Impulse);
    }
}
