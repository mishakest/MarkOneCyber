using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "IsPressedJumpActionCondition", menuName = "State Machines/Conditions/IsPressedJumpActionCondition")]
public class IsPressedJumpActionConditionSO : StateConditionSO<IsPressedJumpActionCondition> { }

public class IsPressedJumpActionCondition : Condition
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    protected override bool Statement()
    {
        if (_protagonist.JumpInput)
        {
            _protagonist.UseJumpInput();
            return true;
        }

        return false;
    }
}