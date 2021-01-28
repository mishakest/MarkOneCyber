using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.StateMachine.ScriptableObjects;
using MoveDirection = MarkOne.Input.InputReader.MoveDirection;

[CreateAssetMenu(fileName = "ApplyHorizontalMovementAction", menuName = "State Machines/Actions/ApplyHorizontalMovementAction")]
public class ApplyHorizontalMovementActionSO : StateActionSO
{
    [SerializeField] private float _laneChangeSpeed = default;

    protected override StateAction CreateAction() => new ApplyHorizontalMovementAction(_laneChangeSpeed);
}

public class ApplyHorizontalMovementAction : StateAction
{
    private Protagonist _protagonist;
    private float _laneChangeSpeed;

    private Vector3 TargetPosition;
    private float lane;

    public ApplyHorizontalMovementAction(float laneChangeSpeed)
    {
        this._laneChangeSpeed = laneChangeSpeed;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _protagonist = stateMachine.GetComponent<Protagonist>();
    }

    public override void OnUpdate()
    {
        TargetPosition = new Vector3()
        {
            x = lane,
            y = _protagonist.transform.position.y,
            z = _protagonist.transform.position.z
        };

        ApplyMovement();
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
        lane = (int)_protagonist.CurrentLane * _protagonist.Preferences.LaneOffset;
    }

    private void ApplyMovement()
    {
        _protagonist.transform.localPosition = Vector3.MoveTowards(_protagonist.transform.localPosition, TargetPosition, _laneChangeSpeed * Time.deltaTime);
    }
}
