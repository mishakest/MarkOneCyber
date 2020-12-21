using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class Actor : MonoBehaviour
{
    #region [CHECKS]

    [Header("Checks")]

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _ceilingCheck;

    #endregion
    #region [FSM]

    [Header("Data")]
    public ActorData Data;
    public StateMachine StateMachine { get; private set; }

    #endregion
    #region [MONO COPMONENTS]
    public InputHandler InputHandler { get; private set; }

    #endregion
    #region [STATES]

    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public SlideState SlideState { get; private set; }
    public DeathState DeathState { get; private set; }

    #endregion
    #region [CHARACTER SETUP]

    public Character Character { get; private set; }

    [Header("Collider")]
    public CharacterCollider Collider;

    #endregion

    public Lane CurrentLane { get; set; }
    public bool IsAlive { get; private set; }

    #region [UNITY CALLBACK]
    private void Awake()
    {
        StateMachine = new StateMachine();

        CurrentLane = Lane.Middle;

        JumpState = new JumpState(this, Data, StateMachine, "jump");
        SlideState = new SlideState(this, Data, StateMachine, "slide");
        DeathState = new DeathState(this, Data, StateMachine, "death");
        RunState = new RunState(this, Data, StateMachine, "run");
    }

    private void Start()
    {
        IsAlive = true;

        InputHandler = GetComponent<InputHandler>();
        Character = Collider.GetComponentInChildren<Character>();
        StateMachine.Init(RunState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Tick();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsTick();
    }

    #endregion
    #region [OTHER METHODS]

    public void ApplyWaringDamage()
    {
        throw new NotImplementedException();
    }

    public bool CheckIfTouchingGround()
    {
        var info = Physics.OverlapSphere(_groundCheck.position, Data.GroundCheckRadius, Data.WhatIsGround);

        return info.Length > 0;
    }

    public bool CheckSpaceAbove()
    {
        var info = Physics.OverlapSphere(_ceilingCheck.position, Data.GroundCheckRadius, Data.WhatIsCeiling);

        return info.Length > 0;
    }

    #endregion
}
