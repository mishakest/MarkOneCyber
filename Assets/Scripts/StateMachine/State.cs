using UnityEngine;

namespace MarkOne.StateMachine
{
    public abstract class State<T> where T : Actor<T>
    {
        protected T Actor;
        protected StateMachine<T> StateMachine;

        protected float StateEnterTime;
        private string _animationName;

        public State(T actor, StateMachine<T> stateMachine, string animationName)
        {
            this.Actor = actor;
            this.StateMachine = stateMachine;
            this._animationName = animationName;
        }

        public virtual void OnStateEnter() 
        {
            CheckConditions();
            StateEnterTime = Time.time;
            Actor.Animator.SetBool(_animationName, true);
        }

        public virtual void OnStateExit() 
        {
            Actor.Animator.SetBool(_animationName, false);
        }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateFixedUpdate() 
        {
            CheckConditions();
        }
        public virtual void CheckConditions() { }
    }
}