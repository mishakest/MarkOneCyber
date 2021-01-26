using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsDeadConditionSO", menuName = "State Machines/Conditions/IsDeadConditionSO")]
public class IsDeadConditionSO : StateConditionSO<IsDeadCondition> { }

public class IsDeadCondition : Condition
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    protected override bool Statement() => _protagonist.IsDead;
}