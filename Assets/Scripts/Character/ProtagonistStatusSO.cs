using UnityEngine;

[CreateAssetMenu(fileName = "ProtagonistStatus", menuName = "Protagonist/Protagonist Status")]
public class ProtagonistStatusSO : ScriptableObject
{
    [HideInInspector] public float LaneOffset;
    [HideInInspector] public float AnimatiionSpeedMultiplyer;

    [HideInInspector] public bool IsDead;
}