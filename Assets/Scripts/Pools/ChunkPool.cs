using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChunkPool : MonoBehaviour
{
    public Chunk LastGeneratedChunk => _createdOnRunChunks[_createdOnRunChunks.Count - 1];

    [SerializeField] private List<GameObject> _chunkPrefabs;

    private List<Chunk> _createdChunks = new List<Chunk>();
    private List<Chunk> _createdOnRunChunks = new List<Chunk>();

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

    //todo: make code look cleaner
    public Chunk GetChunk()
    {
        int index = Random.Range(0, _chunkPrefabs.Count);
        Chunk chunk = _createdChunks[index];

        if (chunk.isActiveAndEnabled)
        {
            var newChunk = Instantiate(chunk.gameObject, transform).GetComponent<Chunk>();
            newChunk.gameObject.SetActive(false);
            _createdOnRunChunks.Add(newChunk);

            return newChunk;
        }

        return chunk;
    }
}
