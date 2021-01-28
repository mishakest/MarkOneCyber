using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[ExecuteAlways]
public class ChunksPool : MonoBehaviour
{
    [SerializeField] private int _intances = 1;
    [SerializeField] private List<GameObject> _chunkPrefabs;

    public List<Chunk> CreatedOnRunChunks { get; private set; }
    [HideInInspector] public List<Chunk> CreatedChunks = new List<Chunk>();

    [HideInInspector] public bool HasBeenPrewarmed = false;

    private void Awake()
    {
        CreatedOnRunChunks = new List<Chunk>();

        if (!HasBeenPrewarmed || CreatedChunks.Count == 0)
            Generate();
    }

    private void Generate()
    {
        for (int i = 0; i < _intances; i++)
        {
            foreach (var chunk in _chunkPrefabs)
            {
                var createdChunk = Instantiate(chunk);
                ApplyChunkPreferences(createdChunk);

                CreatedChunks.Add(createdChunk.GetComponent<Chunk>());
            }
        }
        HasBeenPrewarmed = true;
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
        HasBeenPrewarmed = false;
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

        var chunk = FindDisableDuplicate(index);

        return chunk == null ? CreateChunkOnRun(index) : chunk;
    }

    public void DestroyCreatedChunk(Chunk chunk)
    {
        Destroy(chunk.gameObject);
        CreatedOnRunChunks.Remove(chunk);
    }

    private Chunk FindDisableDuplicate(int index)
    {
        var checkIndex = index;

        for (int i = 0; i < _intances; i++)
        {
            int loopedCheckIndex = checkIndex > CreatedChunks.Count - 1 ? checkIndex - CreatedChunks.Count : checkIndex;

            if (!CreatedChunks[loopedCheckIndex].gameObject.activeInHierarchy)
                return CreatedChunks[loopedCheckIndex];

            checkIndex += (_intances + 1);
        }

        return null;
    }

    private Chunk CreateChunkOnRun(int index)
    {
        var createdChunk = Instantiate(CreatedChunks[index].gameObject);
        ApplyChunkPreferences(createdChunk);

        var chunk = createdChunk.GetComponent<Chunk>();
        CreatedOnRunChunks.Add(chunk);

        return chunk;
    }

    private void ApplyChunkPreferences(GameObject chunk)
    {
        chunk.SetActive(false);
        chunk.transform.parent = transform;
    }
}
