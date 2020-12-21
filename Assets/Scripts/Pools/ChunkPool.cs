using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _chunkPrefabs;

    private List<Chunk> _createdChunks = new List<Chunk>();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach (var chunk in _chunkPrefabs)
        {
            var createdChunk = Instantiate(chunk, this.transform).GetComponent<Chunk>();
            createdChunk.gameObject.SetActive(false);
            _createdChunks.Add(createdChunk);
        }
    }

    public Chunk GetChunk()
    {
        var index = Random.Range(0, _createdChunks.Count);
        return _createdChunks[index];
    }
}
