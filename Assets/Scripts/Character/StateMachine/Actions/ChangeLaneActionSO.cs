using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using MoveDirection = InputReader.MoveDirection;

[CreateAssetMenu(fileName = "ChangeLaneAction", menuName = "State Machines/Actions/Change Lane")]
public class ChangeLaneActionSO : StateActionSO
{
    [SerializeField] private float _laneChangeSpeed = default;

    protected override StateAction CreateAction() => new ChangeLaneAction(_laneChangeSpeed);
}

public class ChangeLaneAction : StateAction
{
    private Protagonist _protagonist;
    private float _laneChangeSpeed;

    private float target;

    public ChangeLaneAction(float laneChangeSpeed)
    {
        this._laneChangeSpeed = laneChangeSpeed;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnUpdate()
    {
        _protagonist.TargetPosition = new Vector3()
        {
            x = target,
            y = _protagonist.transform.position.y,
            z = _protagonist.transform.position.z
        };

        _protagonist.transform.localPosition = Vector3.MoveTowards(_protagonist.transform.localPosition, _protagonist.TargetPosition, _laneChangeSpeed * Time.deltaTime);
        if (_protagonist.MoveInput != MoveDirection.None)
        {
            ChangeLane(_protagonist.MoveInput);
            _protagonist.UseMoveInput();
        }
    }

    private void ChangeLane(MoveDirection direction)
    {
        var targetLane = _protagonist.CurrentLane + (int)direction;

        if (targetLane < Lane.Left || targetLane > Lane.Right)
        {
            return;
        }

        _protagonist.CurrentLane = targetLane;
        //_protagonist.TargetPosition = Vector3.right * (int)_protagonist.CurrentLane * _protagonist.Data.LaneOffset;
        target = (int)_protagonist.CurrentLane * _protagonist.Data.LaneOffset;
    }
}
