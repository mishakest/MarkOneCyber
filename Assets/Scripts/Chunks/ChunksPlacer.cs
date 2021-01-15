using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [Header("Chunks")]
    [SerializeField] private ChunksPool _chunksPool;
    [SerializeField] private Chunk _startingChunk;

    [Header("Preferences")]
    [SerializeField] private float _prespawnDistance = 150.0f;
    [SerializeField] private int _maxChunksOnScene = 3;

    public List<Chunk> SpawnedChunks { get; private set; }

    private void Start()
    {
        SpawnedChunks = new List<Chunk>();
        SpawnedChunks.Add(_startingChunk);
    }

    private void Update()
    {
        if (_player.position.z > GetLastChunk().EndPoint.position.z - _prespawnDistance)
        {
            SpawnChunk();
        }

        if (SpawnedChunks.Count > _maxChunksOnScene)
            DistinctChunk();
    }

    private void SpawnChunk()
    {
        var chunk = _chunksPool.GetChunk();
        chunk.gameObject.SetActive(true);
        chunk.transform.position = GetLastChunk().EndPoint.position - chunk.StartPoint.localPosition;
        SpawnedChunks.Add(chunk);
    }

    private void DistinctChunk()
    {
        var chunk = SpawnedChunks[0];
        chunk.gameObject.SetActive(false);

        foreach (var onRunChunk in _chunksPool.CreatedOnRunChunks)
        {
            if (chunk.gameObject == onRunChunk.gameObject)
            {
                SpawnedChunks.RemoveAt(0);
                _chunksPool.DestroyCreatedChunk(chunk);
                return;
            }
        }

        SpawnedChunks.RemoveAt(0);
    }

    private Chunk GetLastChunk() => SpawnedChunks[SpawnedChunks.Count - 1];
}
