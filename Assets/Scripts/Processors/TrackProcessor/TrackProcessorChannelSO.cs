using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Track Processor/Track Processor Channel")]
public class TrackProcessorChannelSO : ScriptableObject
{
    public float LaneOffset;

    public float StartingSpeed;
    public float CurrentSpeed;
}
