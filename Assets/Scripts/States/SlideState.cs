using UnityEngine;

public class SlideState : MoveState
{
    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Slide State");
        actor.InputHandler.UseSlideInput();
    }
}