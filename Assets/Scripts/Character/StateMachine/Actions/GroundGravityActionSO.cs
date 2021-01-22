using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundGravityAction", menuName = "State Machines/Actions/GroundGravityAction")]
public class GroundGravityActionSO : StateActionSO
{
    [SerializeField] private float _gravityModifier = 2.0f;

    protected override StateAction CreateAction() => new GroundGravityAction(_gravityModifier);
}

public class GroundGravityAction : StateAction
{
    private Vector3 _standardGravity;
    private float _gravityModifier;

    public GroundGravityAction(float gravityModifier)
    {
        this._gravityModifier = gravityModifier;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _standardGravity = Physics.gravity;
    }

    public override void OnStateEnter()
    {
        Physics.gravity = _standardGravity * _gravityModifier;
    }

    public override void OnStateExit()
    {
        Physics.gravity = _standardGravity;
    }

    public override void OnUpdate() { }
}
