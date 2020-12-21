using UnityEngine;

public class MoveState : State
{
    protected bool isTouchingGround;
    private Vector3 _targetPosition;

    public override void Tick()
    {
        base.Tick();


        PeformMovment();

        var input = actor.InputHandler.MovementInput;

        if (input != 0.0f)
        {
            ChangeLane((int)input);
            actor.InputHandler.UseMovementInput();
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isTouchingGround = actor.CheckIfTouchingGround();
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

