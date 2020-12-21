using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor Data", menuName = "Actor/Data")]
public class ActorData : ScriptableObject
{
    [Header("Movement")]
    public float LaneChangeSpeed;

    [Header("Jump")]
    public float JumpForce;

    [Header("Slide")]
    public float MaxSlideTime;
    public float StandColliderHeight;
    public float SlideColliderHeight;

    [Header("Checks")]
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;

}
