using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using Moment = MarkOne.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "AnimatorParameterAction", menuName = "State Machines/Actions/Set Animator Parameter")]
public class AnimatorParameterActionSO : StateActionSO
{
    public ParameterType parameterType = default;
    public string ParameterName = default;

    public bool BoolValue = default;
    public int IntValue = default;
    public float FloatValue = default;

    public Moment WhenToRun = default;

    protected override StateAction CreateAction() => new AnimatorParameterAction(Animator.StringToHash(ParameterName));

    public enum ParameterType
    {
        Bool,
        Int,
        Float,
        Trigger
    }
}

public class AnimatorParameterAction : StateAction
{
    private Animator _animator;
    private AnimatorParameterActionSO _originSO => (AnimatorParameterActionSO)base.OriginSO;
    private int _parameterHash;

    public AnimatorParameterAction(int parameterHash)
    {
        _parameterHash = parameterHash;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponent<Actor>().Character.Animator;
    }

    public override void OnStateEnter()
    {
        if (_originSO.WhenToRun == SpecificMoment.OnStateEnter)
            SetParameter();
    }

    public override void OnStateExit()
    {
        if (_originSO.WhenToRun == SpecificMoment.OnStateExit)
            SetParameter();
    }

    private void SetParameter()
    {
        switch (_originSO.parameterType)
        {
            case AnimatorParameterActionSO.ParameterType.Bool:
                _animator.SetBool(_parameterHash, _originSO.BoolValue);
                break;
            case AnimatorParameterActionSO.ParameterType.Int:
                _animator.SetInteger(_parameterHash, _originSO.IntValue);
                break;
            case AnimatorParameterActionSO.ParameterType.Float:
                _animator.SetFloat(_parameterHash, _originSO.FloatValue);
                break;
            case AnimatorParameterActionSO.ParameterType.Trigger:
                _animator.SetTrigger(_parameterHash);
                break;
        }
    }

    public override void OnUpdate() { }
}
