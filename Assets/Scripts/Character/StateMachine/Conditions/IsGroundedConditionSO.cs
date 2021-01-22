using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsGroundedCondition", menuName = "State Machines/Conditions/IsGroundedCondition")]
public class IsGroundedConditionSO : StateConditionSO<IsGroundedCondition> { }

public class IsGroundedCondition : Condition
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    protected override bool Statement() => _protagonist.CheckIfTouchingGround();
}
