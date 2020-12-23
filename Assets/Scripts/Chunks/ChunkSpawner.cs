using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private ChunkPool _chunkPool;

    public Chunk Spawn(Vector3 position)
    {
        var chunk = _chunkPool.GetChunk();
        chunk.SetSpawnPosition(position);
        chunk.gameObject.SetActive(true);

        return chunk;
    }
}
