using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor Data", menuName = "Actor/Data")]
public class ActorData : ScriptableObject
{
    public float LaneChangeSpeed;

    public float JumpForce;

    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
}
