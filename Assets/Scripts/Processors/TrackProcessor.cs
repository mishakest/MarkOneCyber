using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class TrackProcessor : MonoBehaviour
{ 
    public float Speed { get; private set; }

    [SerializeField] private float _startingSpeed;

    [SerializeField] private ChunkPlacer _chunkPlacer;
    [SerializeField] private Actor _player;

    private void Start()
    {
        Speed = _startingSpeed;
        _chunkPlacer.Player = _player.transform;

        var chunk = _chunkPlacer.StartingChunk;
        _player.LaneOffset = chunk.Ground.GetLaneOffset();
    }

    private void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        foreach (var chunk in _chunkPlacer.SpawnedChunks)
        {
            chunk.Move(Vector3.back, Speed);
        }
    }


}
