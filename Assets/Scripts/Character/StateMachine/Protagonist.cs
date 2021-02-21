using System;
using Extensions;
using UnityEngine;
using MarkOne.StateMachine;
using MarkOne.Input;
using Lane = ProtagonistMoveState.Lane;
using MarkOne.Interfaces;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Protagonist : Actor<Protagonist>
{
    public Character Character { get; private set; }
    public override Animator Animator => Character.Animator;
    public ProtagonistDataSO Data => _data;

    [SerializeField] private InputReader _inputReader = default;

    [Header("Data and Preferences")]
    [SerializeField] private ProtagonistPreferencesSO _preferences = default;
    [SerializeField] private ProtagonistDataSO _data = default;

    [Header("Event Channels")]
    [SerializeField] private CharacterSpawnEventChannelSO _spawnEventChannel = default;
    [SerializeField] private ChracterAnimationChannelSO _animationChannel = default;
    [SerializeField] private ProtagonistStatusEventChannelSO _statusChannel = default;

    [Header("Checks")]
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private Transform _collisionsCheck = default;

    public bool JumpInput { get; private set; }
    public bool SlideInput { get; private set; }
    public InputReader.MoveDirection MoveInput { get; private set; }

    public Lane CurrentLane { get; set; }
    public float LanePosition { get; set; }
    public Vector3 TargetPosition { get; set; }
    public bool IsAnimationEnded { get; private set; }

    public CapsuleCollider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    
    public ProtagonistStatesTable StatesTable { get; private set; }

    private void OnEnable()
    {
        _inputReader.JumpEvent += OnJumpInput;
        _inputReader.SlideEvent += OnSlideInput;
        _inputReader.MoveEvent += OnMove;
        _animationChannel.OnAnimationEnded += EndAnimation;
        _statusChannel.OnProtagonistRevive += Revive;
    }

    private void OnDisable()
    {
        _inputReader.JumpEvent -= OnJumpInput;
        _inputReader.SlideEvent -= OnSlideInput;
        _inputReader.MoveEvent -= OnMove;
        _animationChannel.OnAnimationEnded -= EndAnimation;
        _statusChannel.OnProtagonistRevive -= Revive;
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

        StateMachine.Init(StatesTable.RunState);
    }

    private void FixedUpdate()
    {
        HandleCollisions(hit =>
        {
            Debug.Log("Hit");
            _statusChannel.RaiseEvent(true);
        });
    }

    private void HandleCollisions(Action<IHitable> handler)
    {
        var colliders = Physics.OverlapSphere(_collisionsCheck.position, _data.CollisionsCheckRadius);
        foreach (var collider in colliders)
        {
            var hit = collider.gameObject.GetComponent<Obstacle>();
            if (hit != null)
                handler?.Invoke(hit);
        }
    }

    private void Revive()
    {
        DestroyObstaclesAround(_data.DestroyObstaclesRadius);
    }

    private void DestroyObstaclesAround(float radius)
    {
        var colliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (var collider in colliders)
        {
            collider.gameObject.HandleComponent<Obstacle>(obstacle => obstacle.Destroy());
        }
    }

    private void OnJumpInput() => JumpInput = true;
    private void OnSlideInput() => SlideInput = true;
    private void OnMove(InputReader.MoveDirection movement) => MoveInput = movement;

    public void UseSlideInput() => SlideInput = false;
    public void UseJumpInput() => JumpInput = false;
    public void UseMoveInput() => MoveInput = InputReader.MoveDirection.None;
    public void UseAnimation() => IsAnimationEnded = false;

    private void EndAnimation() => IsAnimationEnded = true;

    public bool CheckIsTouchingGround()
    {
        return Physics.CheckSphere(_groundCheck.position, Data.GroundCheckRadius, Data.WhatIsGround);
    }
}
