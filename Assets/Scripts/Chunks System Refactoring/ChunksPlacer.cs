using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Chunk[] _chunkPrefabs;
    [SerializeField] private Chunk _startingChunk;

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
        if (_player.position.z > SpawnedChunks[SpawnedChunks.Count - 1].EndPoint.position.z - _prespawnDistance)
        {
            SpawnChunk();
        }

        if (SpawnedChunks.Count > _maxChunksOnScene)
            DistinctChunk();
    }

    private void SpawnChunk()
    {
        var index = Random.Range(0, _chunkPrefabs.Length);

        var chunk = Instantiate(_chunkPrefabs[index]);
        chunk.transform.position = SpawnedChunks[SpawnedChunks.Count - 1].EndPoint.position - chunk.StartPoint.localPosition;
        SpawnedChunks.Add(chunk);
    }

    private void DistinctChunk()
    {
        Destroy(SpawnedChunks[0].gameObject);
        SpawnedChunks.RemoveAt(0);
    }
}
