using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649
[RequireComponent(typeof(BoxCollider))]
public class Ground : MonoBehaviour
{
    private const int _lanesAmount = 3;

    [SerializeField] private BoxCollider _collider;

    public float GetLaneOffset()
    {
        return (_collider.size.x / _lanesAmount) / 2;
    }
}
