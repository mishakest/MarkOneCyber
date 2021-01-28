using UnityEngine;

[CreateAssetMenu(fileName = "TrackProcessorData", menuName = "Processors/TrackProcessorData")]
public class TrackProcessorDataSO : ScriptableObject
{
    public float StartingSpeed = 1.0f;
    public float CurrentSpeed = 1.0f;
    public float LaneOffset = 1.66667f;
}