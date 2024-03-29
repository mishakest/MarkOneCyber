﻿using UnityEngine;

[CreateAssetMenu(menuName = "Protagonist/Data")]
public class ProtagonistDataSO : ScriptableObject
{
    public float LaneChangeSpeed = 9.0f;
    public float JumpForce = 7.0f;
    public float JumpToSlideForce = 3.0f;
    public float SlideTime = 1.5f;

    public float StayColliderHeight = 1.9f;
    public float SlideCollierHeight = 1.1f;

    public float GroundCheckRadius = 0.2f;
    public LayerMask WhatIsGround = default;

    [HideInInspector] public float LaneOffset = 1.66667f;
    [HideInInspector] public float AnimatorMultiplier = 1.0f;
}