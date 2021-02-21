using System;
using System.Collections.Generic;
using System.Threading;
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

        private bool _isStopped = false;

        private void OnEnable()
        {
            _protagonistStatus.OnProtagonistDeath += StopMoving;
            _protagonistStatus.OnProtagonistRevive += ContinueMoving;
        }

        private void OnDisable()
        {
            _protagonistStatus.OnProtagonistDeath -= StopMoving;
            _protagonistStatus.OnProtagonistRevive += ContinueMoving;
        }

        private void Start()
        {
            _isStopped = false;
        }

        private void Update()
        {
            if (_isStopped)
                return;

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

        private void StopMoving()
        {
            _isStopped = true;
        }

        private void ContinueMoving()
        {
            _isStopped = false;
        }
    }
}