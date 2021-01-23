using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "IsPressedMoveCondition", menuName = "State Machines/Conditions/IsPressedMoveCondition")]
public class IsPressedMoveActionSO : StateConditionSO<IsPressedMoveAction> { }

public class IsPressedMoveAction : Condition
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    protected override bool Statement()
    {
        if (_protagonist.MoveInput != InputReader.MoveDirection.None)
            return true;

        return false;
    }
}