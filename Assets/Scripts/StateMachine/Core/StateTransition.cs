namespace MarkOne.StateMachine
{
    public class StateTransition : IStateComponent
    {
        private State _targetState;
        private StateCondition[] _conditions;
        private int[] _resultGroups;
        private bool[] _results;

        internal StateTransition() { }

        public StateTransition(State targetState, StateCondition[] conditions, int[] resultGroups = null)
        {
            Init(targetState, conditions, resultGroups);
        }

        internal void Init(State targetState, StateCondition[] conditions, int[] resultGroups = null)
        {
            _targetState = targetState;
            _conditions = conditions;
            _resultGroups = resultGroups;
            _results = new bool[_resultGroups.Length];
        }

        public bool TryGetTransition(out State state)
        {
            state = ShouldTransition() ? _targetState : null;
            return state != null;
        }

        public void OnStateEnter()
        {
            for (int i = 0; i < _conditions.Length; i++)
                _conditions[i].condition.OnStateEnter();
        }

        public void OnStateExit()
        {
            for (int i = 0; i < _conditions.Length; i++)
                _conditions[i].condition.OnStateExit();
        }

        private bool ShouldTransition()
        {
#if UNITY_EDITOR
            _targetState.stateMachine.debugger.TransitionEvaluationBegin(_targetState.originSO.name);
#endif

            int count = _resultGroups.Length;

            for (int i = 0, idx = 0; i < count && idx < _conditions.Length; i++)
                for (int j = 0; j < _resultGroups[i]; j++, idx++)
                    _results[i] = j == 0 ?
                        _conditions[idx].IsMet() :
                        _results[i] && _conditions[idx].IsMet();

            bool ret = false;
            for (int i = 0; i < count && !ret; i++)
                ret = ret || _results[i];

#if UNITY_EDITOR
            _targetState.stateMachine.debugger.TransitionEvaluationEnd(ret, _targetState.actions);
#endif

            return ret;
        }

        internal void ClearConditionsCache()
        {
            for (int i = 0; i < _conditions.Length; i++)
                _conditions[i].condition.ClearStatementCache();
        }
    }
}