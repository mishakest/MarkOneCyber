using System.Collections.Generic;
using MarkOne.Interfaces;
using UnityEngine;

namespace Processors
{
    public class TrackProcessor : MonoBehaviour
    {
        [SerializeField] private TrackProcessorProviderSO _provider = default;
        [SerializeField] private TrackProcessorDataSO _data = default;

        [Space] 
        [SerializeField] private ProtagonistPreferencesSO _protagonistPreferences = default;
        [SerializeField] private ProtagonistStatusEventChannelSO _protagonistStatus = default; 
        
        private void Update()
        {
            ApplyMovement(_provider.ChunksMoveables, _data.ChunksMoveablesMultiplier);
            ApplyMovement(_provider.DynamicMoveables, _data.DynamicMoveablesMultiplier);
        }

        private void ApplyMovement(IEnumerable<IMoveable> moveables, AnimationCurve multiplier)
        {
            foreach (var moveable in moveables)
            {
                var speed = _data.StartingSpeed * multiplier.Evaluate(Time.time);
                moveable.Move(Vector3.back * speed);
            }
        }
    }
}