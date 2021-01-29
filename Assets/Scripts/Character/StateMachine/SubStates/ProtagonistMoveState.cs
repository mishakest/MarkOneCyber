using UnityEngine;
using MarkOne.StateMachine;
using MoveDirection = MarkOne.Input.InputReader.MoveDirection;

public class ProtagonistMoveState : State<Protagonist>
{
    private Vector3 _targetPosition;
    private float _lane;

    public ProtagonistMoveState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        _targetPosition = new Vector3()
        {
            x = _lane,
            y = Actor.transform.position.y,
            z = Actor.transform.position.z
        };

        ApplyMovement();
        if (Actor.MoveInput != MoveDirection.None)
        {
            ChangeLane(Actor.MoveInput);
            Actor.UseMoveInput();
        }
    }

    private void ChangeLane(MoveDirection direction)
    {
        var targetLane = Actor.CurrentLane + (int)direction;

        if (targetLane < Lane.Left || targetLane > Lane.Right)
        {
            return;
        }

        Actor.CurrentLane = targetLane;
        _lane = (int)Actor.CurrentLane * Actor.Preferences.LaneOffset;
    }

    private void ApplyMovement()
    {
        Actor.transform.localPosition = Vector3.MoveTowards(Actor.transform.localPosition, _targetPosition, Actor.Data.LaneChangeSpeed * Time.deltaTime);
    }

    public enum Lane
    {
        Left = -1,
        Middle = 0,
        Right = 1
    }
}