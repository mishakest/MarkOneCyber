using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class TrackProcessor : MonoBehaviour
{
    [SerializeField] private TrackProcessorChannelSO _trackProcessorChannel;
    [SerializeField] private ProtagonistStatusEventChannelSO _protagonistStatusChannel;
    [SerializeField] private ProtagonistPreferencesSO _protagonistPreferences;

    [Space]
    [SerializeField] private float _startAnimationSpeedMultiplyer;

    [Space]
    [SerializeField] private ChunksPlacer _chunksPlacer;

    private void OnEnable()
    {
        _protagonistStatusChannel.OnProtagonistDeath += Stop;
    }

    private void OnDisable()
    {
        _protagonistStatusChannel.OnProtagonistDeath -= Stop;
    }

    private void Start()
    {
        _protagonistPreferences.LaneOffset = _trackProcessorChannel.LaneOffset;
        _protagonistPreferences.AnimatiionSpeedMultiplyer = _startAnimationSpeedMultiplyer;
    }

    private void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        foreach (var chunk in _chunksPlacer.SpawnedChunks)
        {
            chunk.Move(Vector3.back * _trackProcessorChannel.CurrentSpeed);
        }
    }

    private void Stop()
    {
        _trackProcessorChannel.CurrentSpeed = 0.0f;
    }
}
