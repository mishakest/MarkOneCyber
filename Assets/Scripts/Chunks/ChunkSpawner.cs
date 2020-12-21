using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private TrackProcessor _trackProcessor;
    [SerializeField] private ChunkPool _chunkPool;

    public void Spawn()
    {
        var chunk = _chunkPool.GetChunk();
        chunk.transform.parent = this.transform;
        chunk.gameObject.SetActive(true);
        _trackProcessor.AvailableChunks.Add(chunk);
    }
}
