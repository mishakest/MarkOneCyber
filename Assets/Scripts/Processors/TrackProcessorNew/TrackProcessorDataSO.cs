using UnityEngine;

namespace Processors
{
    [CreateAssetMenu(fileName = "TrackProcessorData", menuName = "Processors/TrackProcessorData")]
    public class TrackProcessorDataSO : ScriptableObject
    {
        public AnimationCurve ChunksMoveablesMultiplier = default;
        public AnimationCurve DynamicMoveablesMultiplier = default;

        public float DestroyObstaclesAroundRadius = 4.0f;
        public float StartingSpeed = 20.0f;
    }
}