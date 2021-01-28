using Extensions;
using UnityEngine;

public class TrackProcessor : MonoBehaviour
{
    [SerializeField] private TrackProcessorDataSO _data = default;
    [Space]
    [SerializeField] private ProtagonistPreferencesSO _protagonistPreferences = default;
    [SerializeField] private ProtagonistStatusEventChannelSO _protagonistStatus = default;
    [Space]
    [SerializeField] private ChunksPlacer _chunkPlacer = default;

    [Space]
    [SerializeField] private float _destroyObstaclesRadius = 4.0f;
    [SerializeField] private AnimationCurve _speedMutiplierCurve = default;
    [SerializeField] private AnimationCurve _animationMultiplierCurve = default;
    [SerializeField] private AnimationCurve _movingObjectsMultiplierCurve = default;

    [Space]
    [SerializeField] private bool _drawGizmos = false;

    private bool _isStopped = false;

    private void OnEnable()
    {
        _protagonistStatus.OnProtagonistDeath += Stop;
        _protagonistStatus.OnProtagonistRevive += Continue;
    }

    private void OnDisable()
    {
        _protagonistStatus.OnProtagonistDeath -= Stop;
        _protagonistStatus.OnProtagonistRevive -= Continue;
    }

    private void Awake()
    {
        _data.CurrentSpeed = _data.StartingSpeed;
        _protagonistPreferences.LaneOffset = _data.LaneOffset;
    }

    private void Update()
    {
        if (!_isStopped)
        {
            ApplyChunksMovement();
            ChangeCurrentSpeed();
            ChangeAnimatorMultiplier();
        }
    }

    private void ApplyChunksMovement()
    {
        foreach (var chunk in _chunkPlacer.SpawnedChunks)
            chunk.Move(Vector3.back * _data.CurrentSpeed);
    }

    private void ChangeCurrentSpeed()
    {
        _data.CurrentSpeed = _data.StartingSpeed * _speedMutiplierCurve.Evaluate(Time.time);
    }

    private void ChangeAnimatorMultiplier()
    {
        _protagonistPreferences.AnimatorMultiplier = _animationMultiplierCurve.Evaluate(Time.time);
    }

    private void Stop()
    {
        _isStopped = true;
        _data.CurrentSpeed = 0.0f;
    }

    private void Continue()
    {
        DestroyObstaclesAroundPlayer();
        _isStopped = false;
    }

    private void DestroyObstaclesAroundPlayer()
    {
        var colliders = Physics.OverlapSphere(this.transform.position, _destroyObstaclesRadius);

        foreach (var collider in colliders)
        {
            collider.gameObject.HandleComponent<Obstacle>(obstacle =>
            {
                obstacle.Destroy();
            });
        }
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmos)
        {
            Gizmos.color = new Color32(54, 197, 103, 100);
            Gizmos.DrawSphere(this.transform.position, _destroyObstaclesRadius);
        }
    }
}
