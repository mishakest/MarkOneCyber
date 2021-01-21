using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
public class Settings : MonoBehaviour
{
    [SerializeField] private TrackProcessorChannelSO _trackProcessorChannel;

    [Header("Lane Offset")]
    [SerializeField] private GameObject _chunk;

    [Header("Speeds")]
    [SerializeField] private float _startingSceneSpeed;

    private void Awake()
    {
        var ground = _chunk.GetComponentInChildren<BoxCollider>();
        _trackProcessorChannel.LaneOffset = (ground.size.x / 3) / 2;

        _trackProcessorChannel.StartingSpeed = _startingSceneSpeed;
        _trackProcessorChannel.CurrentSpeed = _startingSceneSpeed;
    }
}
