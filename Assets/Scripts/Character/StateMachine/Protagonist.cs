using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.Input;
using Lane = ProtagonistMoveState.Lane;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Protagonist : Actor<Protagonist>
{
    public Character Character { get; private set; }
    public override Animator Animator => Character.Animator;
    public ProtagonistPreferencesSO Preferences => _preferences;
    public ProtagonistDataSO Data => _data;

    [SerializeField] private InputReader _inputReader = default;

    [Header("Data and Preferences")]
    [SerializeField] private ProtagonistPreferencesSO _preferences = default;
    [SerializeField] private ProtagonistDataSO _data = default;

    [Header("Event Channels")]
    [SerializeField] private ProtagonistStatusEventChannelSO _statusEventChannel = default;
    [SerializeField] private CharacterSpawnEventChannelSO _spawnEventChannel = default;

    [Header("Checks")]
    [SerializeField] private Transform _groundCheck = default;

    public bool JumpInput { get; private set; }
    public bool SlideInput { get; private set; }
    public InputReader.MoveDirection MoveInput { get; private set; }

    public Lane CurrentLane { get; set; }
    public float LanePoisition { get; set; }
    public Vector3 TargetPosition { get; set; }
    public bool IsDead { get; private set; }

    public CapsuleCollider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    
    public ProtagonistStatesTable StatesTable { get; private set; }

    private void OnEnable()
    {
        _inputReader.JumpEvent += OnJumpInput;
        _inputReader.SlideEvent += OnSlideInput;
        _inputReader.MoveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.JumpEvent -= OnJumpInput;
        _inputReader.SlideEvent -= OnSlideInput;
        _inputReader.MoveEvent -= OnMove;
    }

    protected override void Awake()
    {
        base.Awake();

        StatesTable = new ProtagonistStatesTable(this, StateMachine);
        StatesTable.Init();

        CurrentLane = Lane.Middle;
        _spawnEventChannel.RaiseEvent(this.transform);
        Character = GetComponentInChildren<Character>();
        Collider = GetComponent<CapsuleCollider>();
        Rigidbody = GetComponent<Rigidbody>();
        IsDead = false;

        StateMachine.Init(StatesTable.RunState);
    }

    private void OnJumpInput() => JumpInput = true;
    private void OnSlideInput() => SlideInput = true;
    private void OnMove(InputReader.MoveDirection movement) => MoveInput = movement;

    public void UseSlideInput() => SlideInput = false;
    public void UseJumpInput() => JumpInput = false;
    public void UseMoveInput() => MoveInput = InputReader.MoveDirection.None;

    public bool CheckIsTouchingGround()
    {
        return Physics.CheckSphere(_groundCheck.position, Data.GroundCheckRadius, Data.WhatIsGround);
    }
}
