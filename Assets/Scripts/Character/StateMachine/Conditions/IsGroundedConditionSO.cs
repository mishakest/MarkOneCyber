using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;

public class IsGroundedConditionSO : StateConditionSO<IsGroundedCondition> { }

public class IsGroundedCondition : Condition
{
    private Actor _actor;

    public override void Awake(StateMachine stateMachine)
    {
        _actor = stateMachine.GetComponent<Actor>();
    }

    protected override bool Statement() => _actor.CheckIfTouchingGround();
}
