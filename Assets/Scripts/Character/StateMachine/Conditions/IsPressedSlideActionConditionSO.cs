using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "IsPressedSlideActionCondition", menuName = "State Machines/Conditions/IsPressedSlideActionCondition")]
public class IsPressedSlideActionConditionSO : StateConditionSO<IsPressedSlideActionCondition> { }

public class IsPressedSlideActionCondition : Condition
{
    private Protagonist _protagonist;

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    protected override bool Statement()
    {
        if (_protagonist.SlideInput)
        {
            _protagonist.UseSlideInput();
            return true;
        }

        return false;
    }
}
