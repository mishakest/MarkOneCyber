namespace MarkOne.StateMachine
{   
    interface IStateComponent
    {
        void OnStateEnter();
        void OnStateExit();
    }
}