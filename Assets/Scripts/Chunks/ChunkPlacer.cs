using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player { get; set; }
    public Chunk StartingChunk => _startingChunk.GetComponent<Chunk>();

    [SerializeField] private float _prespawnDistance;
    [SerializeField] private int _maxChunksOnScene = 3;
    [SerializeField] private GameObject _startingChunk;
    [SerializeField] private ChunkPool _pool;

    public List<Chunk> SpawnedChunks { get; private set; }

    private void Awake()
    {
        SpawnedChunks = new List<Chunk>();
        SpawnedChunks.Add(StartingChunk);
    }

    private void Update()
    {
        int index = SpawnedChunks.Count - 1;

        if (Player.position.z > SpawnedChunks[index].transform.position.z - _prespawnDistance)
        {
            var chunk = Spawn(SpawnedChunks[index].EndPoint.position);
            SpawnedChunks.Add(chunk);
        }

        DisposeChunks();

    }

    private Chunk Spawn(Vector3 previuosChunkEndPosition)
    {
        var chunk = _pool.GetChunk();
        chunk.SetSpawnPosition(previuosChunkEndPosition);
        chunk.gameObject.SetActive(true);

        SpawnedChunks.Add(chunk);

        return chunk;
    }

    //todo: dispose chunks
    private void DisposeChunks()
    {

    }
}

