using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class TrackProcessor : MonoBehaviour
{
    [SerializeField] private TrackProcessorChannelSO _trackProcessorChannel;
    [SerializeField] private ProtagonistStatusEventChannelSO _protagonistStatusChannel;
    [SerializeField] private ProtagonistStatusSO _protagonistStatus;

    [Space]
    [SerializeField] private float _startAnimationSpeedMultiplyer;

    [Space]
    [SerializeField] private ChunksPlacer _chunksPlacer;

    private void Start()
    {
        _protagonistStatus.LaneOffset = _trackProcessorChannel.LaneOffset;
        _protagonistStatus.AnimatiionSpeedMultiplyer = _startAnimationSpeedMultiplyer;
        _protagonistStatus.IsDead = false;
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
}
