using UnityEngine;
using MarkOne.StateMachine;
using MoveDirection = MarkOne.Input.InputReader.MoveDirection;

public class ProtagonistMoveState : State<Protagonist>
{
    protected bool isGrounded;

    public ProtagonistMoveState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        actor.Animator.SetFloat("yVelocity", actor.Rigidbody.velocity.y);

        actor.TargetPosition = new Vector3()
        {
            x = actor.LanePoisition,
            y = actor.transform.position.y,
            z = actor.transform.position.z
        };

        ApplyMovement();
        if (actor.MoveInput != MoveDirection.None)
        {
            ChangeLane(actor.MoveInput);
            actor.UseMoveInput();
        }
    }

    public override void CheckConditions()
    {
        base.CheckConditions();

        isGrounded = actor.CheckIsTouchingGround();
    }

    private void ChangeLane(MoveDirection direction)
    {
        var targetLane = actor.CurrentLane + (int)direction;

        if (targetLane < Lane.Left || targetLane > Lane.Right)
        {
            return;
        }

        actor.CurrentLane = targetLane;
        actor.LanePoisition = (int)actor.CurrentLane * actor.Preferences.LaneOffset;
    }

    private void ApplyMovement()
    {
        actor.transform.position = Vector3.MoveTowards(actor.transform.position, actor.TargetPosition, actor.Data.LaneChangeSpeed * Time.deltaTime);
    }

    public enum Lane
    {
        Left = -1,
        Middle = 0,
        Right = 1
    }
}