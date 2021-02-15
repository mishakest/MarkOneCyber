using MarkOne.StateMachine;

public class ProtagonistStatesTable : StatesTable<Protagonist>
{
    public ProtagonistRunState RunState { get; private set; }
    public ProtagonistJumpState JumpState { get; private set; }
    public ProtagonistInAirState InAirState { get; private set; }
    public ProtagonistLandState LandState { get; private set; }
    public ProtagonistSlideState SlideState { get; private set; }

    public ProtagonistStatesTable(Protagonist actor, StateMachine<Protagonist> stateMachine) : base(actor, stateMachine)
    {
    }

    public override void Init()
    {
        RunState = new ProtagonistRunState(Actor, StateMachine, "run");
        JumpState = new ProtagonistJumpState(Actor, StateMachine, "jump");
        InAirState = new ProtagonistInAirState(Actor, StateMachine, "inAir");
        LandState = new ProtagonistLandState(Actor, StateMachine, "land");
        SlideState = new ProtagonistSlideState(Actor, StateMachine, "slide");
    }
}