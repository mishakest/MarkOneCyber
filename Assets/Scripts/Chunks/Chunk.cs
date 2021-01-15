using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Bounds")]
    public Transform StartPoint;
    public Transform EndPoint;

    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }
}

