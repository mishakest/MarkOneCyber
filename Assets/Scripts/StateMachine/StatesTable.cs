using UnityEngine;

namespace MarkOne.StateMachine
{
    public abstract class StatesTable<T> where T : Actor<T>
    {
        protected T Actor;
        protected StateMachine<T> StateMachine;

        public StatesTable(T actor, StateMachine<T> stateMachine)
        {
            this.Actor = actor;
            this.StateMachine = stateMachine;
        }

        public abstract void Init();
    }
}