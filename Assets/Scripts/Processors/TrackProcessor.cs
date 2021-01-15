using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class TrackProcessor : MonoBehaviour
{ 
    public float Speed { get; private set; }

    [SerializeField] private float _startingSpeed;
    [SerializeField] private Actor _player;
    [SerializeField] private ChunksPlacer _chunksPlacer;

    private void Start()
    {
        _player.LaneOffset = 1.66666f;
        Speed = _startingSpeed;
    }

    private void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        foreach (var chunk in _chunksPlacer.SpawnedChunks)
        {
            chunk.Move(Vector3.back * Speed);
        }
    }


}
