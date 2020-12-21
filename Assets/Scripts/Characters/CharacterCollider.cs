﻿using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterCollider : MonoBehaviour
{
    private CapsuleCollider _collider;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 force, ForceMode forceMode)
    {
        _rigidbody.AddForce(force, forceMode);
    }

    public void SetColliderHeight(float height)
    {
        var center = _collider.center;
        center.y += (height = _collider.radius) / 2;
        _collider.center = center;

        _collider.radius = height;
    }
}
