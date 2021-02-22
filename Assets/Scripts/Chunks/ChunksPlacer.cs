using System;
using System.Collections.Generic;
using System.Linq;
using Processors;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    [SerializeField] private TrackProcessorProviderSO _provider = default;

    [SerializeField] private Chunk _startingChunk = default;
    [SerializeField] private ChunksPool _chunksPool = default;

    [SerializeField] private int _maxChunksOnScene = 3;

    private readonly List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        AddChunk(_startingChunk);
    }

    private void Update()
    {
        if (_spawnedChunks.Count < _maxChunksOnScene)
            PlaceChunk();

        if (_spawnedChunks.First().EndPoint.position.z < -10.0f)
            DistinctChunk();
    }

    private void AddChunk(Chunk chunk)
    {
        _provider.ChunksMoveables.Add(chunk);
        _spawnedChunks.Add(chunk);
    }

    private void RemoveChunk(Chunk chunk)
    {
        _provider.ChunksMoveables.Remove(chunk);
        _spawnedChunks.Remove(chunk);
    }

    private void PlaceChunk()
    {
        var chunk = _chunksPool.Request();
        chunk.gameObject.SetActive(true);
        chunk.transform.position = GetConnectionPointPosition(chunk);
        AddChunk(chunk);
    }

    private void DistinctChunk()
    {
        var chunk = _spawnedChunks[0];
        chunk.gameObject.SetActive(false);

        if (_chunksPool.CreatedOnRunChunks.Any(onRunChunk => chunk.gameObject == onRunChunk.gameObject))
        {
            RemoveChunk(chunk);
            _chunksPool.DestroyCreatedChunk(chunk);
            return;
        }

        RemoveChunk(chunk);
    }

    private Vector3 GetConnectionPointPosition(Chunk currentChunk)
    {
        return _spawnedChunks.Last().EndPoint.position - currentChunk.StartPoint.localPosition;
    }
}