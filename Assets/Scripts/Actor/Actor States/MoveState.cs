using UnityEngine;

public class MoveState : State
{
    protected bool isTouchingGround;
    protected bool isTouchingCeiling;

    protected int movementInput;
    protected bool jumpInput;
    protected bool slideInput;

    protected Vector3 velocity;

    public MoveState(Actor actor, ActorData data, StateMachine stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }

    public override void Tick()
    {
        base.Tick();

        movementInput = actor.InputHandler.MovementInput;
        jumpInput = actor.InputHandler.JumpInput;
        slideInput = actor.InputHandler.SlideInput;

        PerformMoving();

        if (movementInput != 0.0f)
        {
            ChangeLane(movementInput);
            actor.InputHandler.UseMovementInput();
        }

        //todo: replace silly logic
        if (isTouchingGround && !actor.BlobShadow.activeInHierarchy)
        {
            actor.EnableShadow();
        }
        else if (!isTouchingGround) 
        {
            actor.DisableShadow();
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isTouchingGround = actor.CheckIfTouchingGround();
        isTouchingCeiling = actor.CheckSpaceAbove();
        velocity = actor.Collider.GetVelocity();
    }

    protected void ChangeLane(int direction)
    {
        var targetLane = actor.CurrentLane + direction;

        if (targetLane < Lane.Left || targetLane > Lane.Right)
        {
            actor.ApplyWaringDamage();
            return;
        }

        actor.CurrentLane = targetLane;
        actor.TargetPosition = Vector3.right * (int)actor.CurrentLane * actor.Data.LaneOffset;
    }

    private void PerformMoving()
    {
        actor.transform.localPosition = Vector3.MoveTowards(actor.transform.localPosition, actor.TargetPosition, data.LaneChangeSpeed * Time.deltaTime);
    }
}

public enum Lane
{
    Left = -1,
    Middle = 0,
    Right = 1
}

