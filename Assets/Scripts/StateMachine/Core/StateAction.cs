using MarkOne.StateMachine.ScriptableObjects;

namespace MarkOne.StateMachine
{
    public abstract class StateAction : IStateComponent
    {
        internal StateActionSO originSO;
        protected StateActionSO OriginSO => originSO;

        public abstract void OnUpdate();

        public virtual void Awake(StateMachine stateMachine) { }

        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        public enum SpecificMoment
        {
            OnStateEEnter,
            OnStateExit,
            OnUpdate
        }
    }
}