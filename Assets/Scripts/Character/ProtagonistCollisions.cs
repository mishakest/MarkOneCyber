using System;
using UnityEngine;
using Extensions;


public class ProtagonistCollisions : MonoBehaviour
{
    [SerializeField] private ProtagonistStatusEventChannelSO _statusChannel = default;

    [SerializeField] private Transform[] _checkOrigins;
    [SerializeField] private float _raycastDistance = 1.0f;

    private void FixedUpdate()
    {
        foreach (var origin in _checkOrigins)
        {
            HandleRaycast(origin, hit =>
            {
                hit.transform.gameObject.HandleComponent<Obstacle>(component =>
                {
                    Debug.Log("Hit");
                    _statusChannel.RaiseEvent(true);
                });
            });
        }
    }


    private void HandleRaycast(Transform origin, Action<RaycastHit> handler)
    {
        var success = Physics.Raycast(origin.position, origin.localPosition + Vector3.forward * _raycastDistance,
            out var hit);

        if (success)
            handler?.Invoke(hit);
    }

    private void OnDrawGizmos()
    {
        foreach (var origin in _checkOrigins)
        {
            Gizmos.DrawLine(origin.position, origin.localPosition + Vector3.forward * _raycastDistance);
        }
    }
}