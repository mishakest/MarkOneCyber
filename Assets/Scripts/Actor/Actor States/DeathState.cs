using UnityEngine;

public class DeathState : State
{
    public DeathState(Actor actor, ActorData data, StateMachineOld stateMachine, string animationName) : base(actor, data, stateMachine, animationName)
    {
    }
}
