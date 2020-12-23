using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

#pragma warning disable 0649
public class TrackProcessor : MonoSingletone<TrackProcessor>
{
    private const float offset = 15.0f;

    public float Speed { get; private set; }

    [SerializeField] private float _startingSpeed;

    [SerializeField] private GameObject _startingChunk;
    [SerializeField] private ChunkSpawner _chunkSpawner;
    [SerializeField] private Actor _player;

    private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        Speed = _startingSpeed;

        var chunk = _startingChunk.GetComponent<Chunk>();
        _spawnedChunks.Add(chunk);

        _player.LaneOffset = chunk.Ground.GetLaneOffset();
    }

    private void Update()
    {
        MoveChunks();
        ReplaceChunks();
    }

    public void AddChunk()
    {
        var lastChunkEnd = _spawnedChunks.Last().EndPoint;
        var chunk = _chunkSpawner.Spawn(lastChunkEnd.position);
        _spawnedChunks.Add(chunk);
    }

    private void MoveChunks()
    {
        foreach (var chunk in _spawnedChunks)
        {
            chunk.Move(Vector3.back, Speed);
        }
    }

    private void ReplaceChunks()
    {
        if (_player.transform.position.z > _spawnedChunks.Last().EndPoint.position.z - offset)
        {
            AddChunk();
        }
    }

}
