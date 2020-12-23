using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#pragma warning disable 0649
public class TrackProcessor : MonoSingletone<TrackProcessor>
{
    public float Speed { get; private set; }
    public Chunk CurrentChunk => AvailableChunks.Last();
    public List<Chunk> AvailableChunks { get; private set; }

    [SerializeField] private float _startingSpeed;
    [SerializeField] private GameObject _startingChunkGO;

    private Actor _player;

    private void Start()
    {
        AvailableChunks = new List<Chunk>();
        _player = FindObjectOfType<Actor>();
        Speed = _startingSpeed;

        var chunk = _startingChunkGO.GetComponent<Chunk>();
        _player.LaneOffset = chunk.Ground.GetLaneOffset();
        AvailableChunks.Add(chunk);
    }

    private void Update()
    {
        foreach (var chunk in AvailableChunks)
        {
            var direction = _player.transform.forward.z * Vector3.back;
            chunk.Move(direction, Speed);
        }
    }
}
