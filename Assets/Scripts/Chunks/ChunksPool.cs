using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ChunksPool : MonoBehaviour
{
    [SerializeField] private int _intances = 1;
    [SerializeField] private List<GameObject> _chunkPrefabs;

    public List<Chunk> CreatedOnRunChunks { get; private set; }
    [HideInInspector] public List<Chunk> CreatedChunks = new List<Chunk>();

    private void Awake()
    {
        CreatedOnRunChunks = new List<Chunk>();
    }


    private void Generate()
    {
        for (int i = 0; i < _intances; i++)
        {
            foreach (var chunk in _chunkPrefabs)
            {
                var createdChunk = Instantiate(chunk);
                createdChunk.SetActive(false);
                createdChunk.transform.parent = transform;

                CreatedChunks.Add(createdChunk.GetComponent<Chunk>());
            }
        }
    }

    private void Distinct()
    {
        for (int i = 0; i < CreatedChunks.Count; ++i)
        {
#if UNITY_EDITOR
            DestroyImmediate(CreatedChunks[i].gameObject);
#else
            Destroy(CreatedChunks[i].gameObject)
#endif
        }

        CreatedChunks.Clear();
    }

    public void Reload()
    {
        Distinct();
        Generate();
    }

    public Chunk GetChunk()
    {
        int index = Random.Range(0, CreatedChunks.Count);

        if (!CreatedChunks[index].gameObject.activeInHierarchy)
        {
            return CreatedChunks[index];
        }
        else
        {
            var createdChunk = Instantiate(CreatedChunks[index].gameObject);
            createdChunk.SetActive(false);
            createdChunk.transform.parent = transform;

            var chunk = createdChunk.GetComponent<Chunk>();

            CreatedOnRunChunks.Add(chunk);

            return chunk;
        }
    }

    public void DestroyCreatedChunk(Chunk chunk)
    {
        Destroy(chunk.gameObject);
        CreatedOnRunChunks.Remove(chunk);
    }
}
