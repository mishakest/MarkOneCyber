using MarkOne.StateMachine;

public class ProtagonistStatesTable : StatesTable<Protagonist>
{
    public ProtagonistMoveState MoveState { get; private set; }

    public ProtagonistStatesTable(Protagonist actor, StateMachine<Protagonist> stateMachine) : base(actor, stateMachine)
    {
    }

    public override void Init()
    {
        MoveState = new ProtagonistMoveState(Actor, StateMachine, "");
    }
}