using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Actor actor;
    protected ActorData data;
    protected StateMachine stateMachine;
    protected float startTime;

    private string animationName;

    public State(Actor actor, ActorData data, StateMachine stateMachine, string animationName)
    {
        this.actor = actor;
        this.data = data;
        this.stateMachine = stateMachine;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        DoChecks();
        startTime = Time.time;

        actor.Character.Animator.SetBool(animationName, true);
    }

    public virtual void Exit()
    {
        actor.Character.Animator.SetBool(animationName, false);
    }

    public virtual void Tick()
    {

    }

    public virtual void PhysicsTick()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
