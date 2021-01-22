using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "IsAnimationEndedCondition", menuName = "State Machines/Conditions/IsAnimationEndedCondition")]
public class IsAnimationEndedConditionSO : StateConditionSO
{
    [SerializeField] private AnimationClip _animation = default;

    protected override Condition CreateCondition() => new IsAnimationEndedCondition(_animation);
}

public class IsAnimationEndedCondition : Condition
{
    private AnimationClip _animation;
    private float _enterTime;

    public IsAnimationEndedCondition(AnimationClip animation)
    {
        this._animation = animation;
    }

    public override void OnStateEnter()
    {
        _enterTime = Time.time;
    }

    protected override bool Statement()
    {
        return Time.time >= _enterTime + _animation.length;
    }
}
