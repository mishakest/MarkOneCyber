using UnityEngine;
using MarkOne.StateMachine;

public class ProtagonistMoveState : State<Protagonist>
{
    public ProtagonistMoveState(Protagonist actor, StateMachine<Protagonist> stateMachine, string animationName) : base(actor, stateMachine, animationName)
    {
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();


    }
}