using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class TrackProcessor : MonoSingletone<TrackProcessor>
{
    public float Speed { get; private set; }

    [SerializeField] private float _startingSpeed;
    [SerializeField] private GameObject _startingChunkGO;

    private Actor _player;
    private Chunk _currentChunk;

    public float LaneOffset { get; set; }

    private void Start()
    {
        _player = FindObjectOfType<Actor>();
        Speed = _startingSpeed;

        _currentChunk = _startingChunkGO.GetComponent<Chunk>();
        LaneOffset = _currentChunk.Ground.GetLaneOffset();
        Debug.Log(LaneOffset);
    }

    private void Update()
    {
        var direction =  _player.transform.forward.z * Vector3.back;
        _currentChunk.Move(direction, Speed);
    }
}
