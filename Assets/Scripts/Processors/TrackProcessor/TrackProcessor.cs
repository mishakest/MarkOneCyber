using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class TrackProcessor : MonoBehaviour
{
    [SerializeField] private TrackProcessorChannelSO _trackProcessorChannel;

    [Header("Scene Objects")]
    [SerializeField] private ChunksPlacer _chunksPlacer;

    private void Start()
    {
        //_player.Data.LaneOffset = _trackProcessorChannel.LaneOffset;
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
