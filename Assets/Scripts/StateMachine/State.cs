using UnityEngine;

namespace MarkOne.StateMachine
{
    public abstract class State<T> where T : Actor<T>
    {
        protected T actor;
        protected StateMachine<T> stateMachine;

        protected float stateEnterTime;
        private string _animationName;

        public State(T actor, StateMachine<T> stateMachine, string animationName)
        {
            this.actor = actor;
            this.stateMachine = stateMachine;
            this._animationName = animationName;
        }

        public virtual void OnStateEnter() 
        {
            CheckConditions();
            stateEnterTime = Time.time;
            actor.Animator.SetBool(_animationName, true);
        }

        public virtual void OnStateExit() 
        {
            actor.Animator.SetBool(_animationName, false);
        }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateFixedUpdate() 
        {
            CheckConditions();
        }
        public virtual void CheckConditions() { }
    }
}