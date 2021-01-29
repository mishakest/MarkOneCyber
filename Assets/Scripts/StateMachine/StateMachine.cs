using UnityEngine;

namespace MarkOne.StateMachine
{
    public class StateMachine<T> where T : Actor<T>
    {
        public State<T> CurrentState { get; private set; }

        public void Init(State<T> initialState)
        {
            CurrentState = initialState;
            CurrentState.OnStateEnter();
        }

        public void ChangeState(State<T> newState)
        {
            CurrentState.OnStateExit();
            CurrentState = newState;
            CurrentState.OnStateEnter();
        }
    }
}