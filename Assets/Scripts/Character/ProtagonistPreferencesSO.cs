using UnityEngine;

[CreateAssetMenu(fileName = "ProtagonistStatus", menuName = "Protagonist/Protagonist Status")]
public class ProtagonistPreferencesSO : ScriptableObject
{
    [HideInInspector] public float LaneOffset;
    [HideInInspector] public float AnimatiionSpeedMultiplyer;
}