using MarkOne.StateMachine.ScriptableObjects;

namespace MarkOne.StateMachine
{
    public abstract class Condition : IStateComponent
    {
        private bool _isCached = false;
        private bool _cachedStatement = default;
        internal StateConditionSO originSO;

        protected StateConditionSO OriginSO => originSO;

        protected abstract bool Statement();

        internal bool GetStatement()
        {
            if (!originSO.cacheResult)
                return Statement();

            if (!_isCached)
            {
                _isCached = true;
                _cachedStatement = Statement();
            }

            return _cachedStatement;
        }

        internal void ClearStatementCache()
        {
            _isCached = false;
        }

        public virtual void Awake(StateMachine stateMachine) { }
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
    }

    public readonly struct StateCondition
    {
        internal readonly StateMachine stateMachine;
        internal readonly Condition condition;
        internal readonly bool expectedResult;

        public StateCondition(StateMachine stateMachine, Condition condition, bool expectedResult)
        {
            this.stateMachine = stateMachine;
            this.condition = condition;
            this.expectedResult = expectedResult;
        }

        public bool IsMet()
        {
            bool statement = condition.GetStatement();
            bool isMet = statement == expectedResult;

#if UNITY_EDITOR
            stateMachine.debugger.TransitionConditionResult(condition.originSO.name, statement, isMet);
#endif
            return isMet;
        }
    }
}