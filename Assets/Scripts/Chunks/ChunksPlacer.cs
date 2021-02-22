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

    private List<Chunk> _spawnedChunks = new List<Chunk>();

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

//public class ChunksPlacers : MonoBehaviour
//{
//    [SerializeField] private TrackProcessorProviderSO _provider = default;

//    [SerializeField] private Transform _player;

//    [Header("Chunks")]
//    [SerializeField] private ChunksPool _chunksPool;
//    [SerializeField] private Chunk _startingChunk;

//    [Header("Preferences")]
//    [SerializeField] private float _prespawnDistance = 150.0f;
//    [SerializeField] private int _maxChunksOnScene = 3;

//    public List<Chunk> SpawnedChunks { get; private set; }

//    private void Start()
//    {
//        SpawnedChunks = new List<Chunk>();
//        SpawnedChunks.Add(_startingChunk);
//        _provider.ChunksMoveables.Add(_startingChunk);
//    }

//    private void Update()
//    {
//        if (_player.position.z > GetLastChunk().EndPoint.position.z - _prespawnDistance)
//        {
//            SpawnChunk();
//        }

//        if (SpawnedChunks.Count > _maxChunksOnScene)
//            DistinctChunk();
//    }

//    private void SpawnChunk()
//    {
//        var chunk = _chunksPool.Request();
//        chunk.gameObject.SetActive(true);
//        chunk.transform.position = GetLastChunk().EndPoint.position - chunk.StartPoint.localPosition;
//        SpawnedChunks.Add(chunk);
//        _provider.ChunksMoveables.Add(chunk);
//    }

//    private void DistinctChunk()
//    {
//        var chunk = SpawnedChunks[0];
//        chunk.gameObject.SetActive(false);

//        foreach (var onRunChunk in _chunksPool.CreatedOnRunChunks)
//        {
//            if (chunk.gameObject == onRunChunk.gameObject)
//            {
//                SpawnedChunks.RemoveAt(0);
//                _provider.ChunksMoveables.RemoveAt(0);
//                _chunksPool.DestroyCreatedChunk(chunk);
//                return;
//            }
//        }

//        SpawnedChunks.RemoveAt(0);
//        _provider.ChunksMoveables.RemoveAt(0);
//    }

//    private Chunk GetLastChunk() => SpawnedChunks[SpawnedChunks.Count - 1];
//}
