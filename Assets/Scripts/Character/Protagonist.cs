using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Protagonist : MonoBehaviour
{
    public ProtagonistDataSO ProtagonistData = default;
    public ProtagonistSO CharacterSO = default;

    public bool JumpInput { get; private set; }
    public bool SlideInput { get; private set; }

    public InputReader.MoveDirection MoveInput { get; private set; }
    public Lane CurrentLane { get; set; }


    public CapsuleCollider Collider;
    public Rigidbody Rigidbody { get; private set; }

    public ActorData Data = default;


    [SerializeField] private InputReader _inputReader = default;
    [Header("Child Objects")]
    [SerializeField] private GameObject _blobShadow = default;
    [SerializeField] private Transform _groundCheck = default;

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

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        CurrentLane = Lane.Middle;
    }

    public bool CheckIfTouchingGround()
    {
        var info = Physics.OverlapSphere(_groundCheck.position, Data.GroundCheckRadius, Data.WhatIsGround);

        return info.Length > 0;
    }

    private void OnJumpInput() => JumpInput = true;
    private void OnSlideInput() => SlideInput = true;
    private void OnMove(InputReader.MoveDirection movement) => MoveInput = movement;

    public void UseSlideInput() => SlideInput = false;
    public void UseJumpInput() => JumpInput = false;
    public void UseMoveInput() => MoveInput = InputReader.MoveDirection.None;

    public void SetColliderHeight(float height)
    {
        var center = Collider.center;
        center.y += (height - Collider.height) / 2;
        Collider.center = center;
        Collider.height = height;
    }

    public void EnableShadow() => _blobShadow.SetActive(true);
    public void DisableShadow() => _blobShadow.SetActive(false);
}
