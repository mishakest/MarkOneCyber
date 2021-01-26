using UnityEngine;

[CreateAssetMenu(fileName = "ProtagonistData", menuName = "Protagonist/Protagonist Data")]
public class ProtagonistDataSO : ScriptableObject
{
    [Header("Movement Preferences")]
    public float LaneChangeSpeed;
    public float JumpForce;
    public float StandColliderHeight;

    [Header("Checks")]
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;

    [HideInInspector] public float LaneOffset;
    [HideInInspector] public float AnimatiionSpeedMultiplyer;

    [HideInInspector] public bool IsDead;
}