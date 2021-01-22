using MarkOne.StateMachine.ScriptableObjects;

namespace MarkOne.StateMachine
{
    public class State
    {
        internal StateSO originSO;
        internal StateMachine stateMachine;
        internal StateTransition[] transitions;
        internal StateAction[] actions;

        internal State() { }

        public State(StateSO originSO, StateMachine stateMachine, StateTransition[] transitions, StateAction[] actions)
        {
            this.originSO = originSO;
            this.stateMachine = stateMachine;
            this.transitions = transitions;
            this.actions = actions;
        }

        public void OnStateEnter()
        {
            void OnStateEnter(IStateComponent[] components)
            {
                for (int i = 0; i < components.Length; i++)
                    components[i].OnStateEnter();
            }

            OnStateEnter(transitions);
            OnStateEnter(actions);
        }

        public void OnUpdate()
        {
            for (int i = 0; i < actions.Length; i++)
                actions[i].OnUpdate();
        }

        public void OnStateExit()
        {
            void OnStateExit(IStateComponent[] components)
            {
                for (int i = 0; i < components.Length; i++)
                    components[i].OnStateExit();
            }

            OnStateExit(transitions);
            OnStateExit(actions);
        }

        public bool TryGetTransition(out State state)
        {
            state = null;

            for (int i = 0; i < transitions.Length; i++)
            {
                if (transitions[i].TryGetTransition(out state))
                    break;
            }

            for (int i = 0; i < transitions.Length; i++)
                transitions[i].ClearConditionsCache();

            return state != null;
        }
    }
}