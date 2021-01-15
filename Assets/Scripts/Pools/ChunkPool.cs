using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChunkPool : MonoBehaviour
{
    public Chunkold LastGeneratedChunk => _createdOnRunChunks[_createdOnRunChunks.Count - 1];

    [SerializeField] private List<GameObject> _chunkPrefabs;

    private List<Chunkold> _createdChunks = new List<Chunkold>();
    private List<Chunkold> _createdOnRunChunks = new List<Chunkold>();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach (var chunk in _chunkPrefabs)
        {
            var createdChunk = Instantiate(chunk, this.transform).GetComponent<Chunkold>();
            createdChunk.gameObject.SetActive(false);
            _createdChunks.Add(createdChunk);
        }
    }

    //todo: make code look cleaner
    public Chunkold GetChunk()
    {
        int index = Random.Range(0, _chunkPrefabs.Count);
        Chunkold chunk = _createdChunks[index];

        if (chunk.isActiveAndEnabled)
        {
            var newChunk = Instantiate(chunk.gameObject, transform).GetComponent<Chunkold>();
            newChunk.gameObject.SetActive(false);
            _createdOnRunChunks.Add(newChunk);

            return newChunk;
        }

        return chunk;
    }
}
