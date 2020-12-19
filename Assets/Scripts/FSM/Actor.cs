using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class Actor : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;

    public ActorData Data;
    public StateMachine StateMachine { get; private set; }
    public InputHandler InputHandler { get; private set; }

    #region States

    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }

    public SlideState SlideState { get; private set; }
    public DeathState DeathState { get; private set; }

    #endregion

    public Character Character;
    public CharacterCollider Collider;


    public Lane CurrentLane { get; set; }
    public float LaneOffset { get; private set; }

    public Vector3 TargetPosition { get; set; }

    public bool IsAlive { get; private set; }

    private void Awake()
    {
        StateMachine = new StateMachine();

        CurrentLane = Lane.Middle;

        JumpState = new JumpState();
        SlideState = new SlideState();
        DeathState = new DeathState();
        RunState = new RunState();

        InitState(JumpState, "jump");
        InitState(SlideState, "slide");
        InitState(DeathState, "death");
        InitState(RunState, "run");
    }

    private void Start()
    {
        IsAlive = true;

        InputHandler = GetComponent<InputHandler>();
        StateMachine.Init(RunState);

        LaneOffset = TrackProcessor.Instance.LaneOffset;
    }

    private void Update()
    {
        StateMachine.CurrentState.Tick();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsTick();
    }

    private void InitState(State state, string animationName)
    {
        state.Init(this, Data, StateMachine, animationName);
    }

    internal void ApplyWaringDamage()
    {
        throw new NotImplementedException();
    }


    //todo: maybe should change it to raycast
    public bool CheckIfTouchingGround()
    {
        var info = Physics.OverlapSphere(_groundCheck.position, Data.GroundCheckRadius, Data.WhatIsGround);

        return info.Length > 0;
    }
}
