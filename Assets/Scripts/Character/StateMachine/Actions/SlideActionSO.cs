using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "SlideAction", menuName = "State Machines/Actions/SlideAction")]
public class SlideActionSO : StateActionSO
{
    [SerializeField] private float _colliderHeight = default;

    protected override StateAction CreateAction() => new SlideAction(_colliderHeight);
}

public class SlideAction : StateAction
{
    private Protagonist _protagonist;

    private float _colliderHeight;
    private float _standardColliderHeight;

    public SlideAction(float colliderHeight)
    {
        this._colliderHeight = colliderHeight;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
        _standardColliderHeight = _protagonist.Collider.height;
    }

    public override void OnStateEnter()
    {
        _protagonist.SetColliderHeight(_colliderHeight);
    }

    public override void OnStateExit()
    {
        _protagonist.SetColliderHeight(_standardColliderHeight); ;
    }

    public override void OnUpdate() { }
}
