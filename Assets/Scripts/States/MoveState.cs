using UnityEngine;

public class MoveState : State
{
    protected bool isTouchingGround;
    protected bool isTouchingCeiling;

    protected float movementInput;
    protected bool jumpInput;
    protected bool slideInput;

    private Vector3 _targetPosition;

    public MoveState(Actor actor, ActorData data, StateMachine stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }

    public override void Tick()
    {
        base.Tick();

        movementInput = actor.InputHandler.MovementInput;
        jumpInput = actor.InputHandler.JumpInput;
        slideInput = actor.InputHandler.SlideInput;

        PeformMovment();

        if (movementInput != 0.0f)
        {
            ChangeLane((int)movementInput);
            actor.InputHandler.UseMovementInput();
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isTouchingGround = actor.CheckIfTouchingGround();
        isTouchingCeiling = actor.CheckSpaceAbove();
    }

    private void ChangeLane(int direction)
    {
        var targetLane = actor.CurrentLane + direction;

        if (targetLane < Lane.Left || targetLane > Lane.Right)
        {
            actor.ApplyWaringDamage();
            return;
        }

        actor.CurrentLane = targetLane;
        _targetPosition = Vector3.right * ((int)actor.CurrentLane - 1) * TrackProcessor.Instance.LaneOffset;
    }

    private void PeformMovment()
    {
        actor.transform.localPosition = Vector3.MoveTowards(actor.transform.localPosition, _targetPosition, actor.Data.LaneChangeSpeed * Time.deltaTime);
    }
}

public enum Lane
{
    Left,
    Middle,
    Right
}

