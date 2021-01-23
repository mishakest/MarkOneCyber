using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "JumpAction", menuName = "State Machines/Actions/Jump")]
public class JumpActionSO : StateActionSO
{
    [SerializeField] private float _jumpForce = default;

    protected override StateAction CreateAction() => new JumpAction(_jumpForce);
}

public class JumpAction : StateAction
{
    private Protagonist _protagonist;
    private float _jumpForce;

    public JumpAction(float jumpForce)
    {
        this._jumpForce = jumpForce;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnStateEnter()
    {
        _protagonist.Rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public override void OnUpdate() { }
}
