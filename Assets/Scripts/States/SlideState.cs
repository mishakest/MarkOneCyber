using UnityEngine;

public class SlideState : MoveState
{
    public SlideState(Actor actor, ActorData data, StateMachine stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Slide State");
        actor.InputHandler.UseSlideInput();
    }
}