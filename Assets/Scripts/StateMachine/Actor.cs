using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarkOne.StateMachine
{
    public abstract class Actor<T> : MonoBehaviour where T : Actor<T>
    {
        public StateMachine<T> StateMachine { get; protected set; }
        public abstract Animator Animator { get; }

        protected virtual void Awake()
        {
            StateMachine = new StateMachine<T>();
        }

        private void Update()
        {
            StateMachine.CurrentState.OnStateUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.OnStateFixedUpdate();
        }
    } 
}