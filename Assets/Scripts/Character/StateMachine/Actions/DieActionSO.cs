using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "DieAction", menuName = "State Machines/Actions/DieAction")]
public class DieActionSO : StateActionSO<DieAction> { }

public class DieAction : StateAction
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnStateEnter()
    {
        _protagonist.Die();
    }

    public override void OnUpdate() { }
}
