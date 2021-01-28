using MarkOne.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Protagonist : MonoBehaviour
{
    public Character Character { get; private set; }
    public ProtagonistPreferencesSO Preferences => _preferences;

    [SerializeField] private InputReader _inputReader = default;

    [SerializeField] private ProtagonistPreferencesSO _preferences = default;
    [SerializeField] private ProtagonistStatusEventChannelSO _statusEventChannel = default;
    [SerializeField] private CharacterSpawnEventChannelSO _spawnEventChannel = default;

    [Header("Attached Objetcs Preferences")]
    [SerializeField] private GameObject _blobShadow = default;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private LayerMask _whatIsGround = default;
    [Range(0.1f, 0.5f)]
    [SerializeField] private float _groundCheckRadius = 0.2f;


    public bool JumpInput { get; private set; }
    public bool SlideInput { get; private set; }
    public bool IsDead { get; private set; }

    public InputReader.MoveDirection MoveInput { get; private set; }
    public Lane CurrentLane { get; set; }

    public CapsuleCollider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }


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

    private void Awake()
    {
        _spawnEventChannel.RaiseEvent(this.transform);
        Character = GetComponentInChildren<Character>();
        Collider = GetComponent<CapsuleCollider>();
        Rigidbody = GetComponent<Rigidbody>();
        IsDead = false;
    }

    private void Start()
    {
        CurrentLane = Lane.Middle;
    }

    private void Update()
    {
        Character.Animator.SetFloat("runMultiplier", _preferences.AnimatorMultiplier);
    }

    public bool CheckIfTouchingGround()
    {
        var info = Physics.OverlapSphere(_groundCheck.position, _groundCheckRadius, _whatIsGround);

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
    public void Die()
    {
        IsDead = true;
        _statusEventChannel.RaiseEvent(IsDead);
    }

    public void Revive()
    {
        IsDead = false;
        _statusEventChannel.RaiseEvent(IsDead);
    }
}

public enum Lane
{
    Left = -1,
    Middle = 0,
    Right = 1
}
