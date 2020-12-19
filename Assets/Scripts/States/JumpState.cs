using UnityEngine;

public class JumpState : MoveState
{
    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Jump State");
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
