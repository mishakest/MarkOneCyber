using MarkOne.Interfaces;
using UnityEngine;

public class Chunk : MonoBehaviour, IMoveable
{
    [Header("Bounds")]
    public Transform StartPoint;
    public Transform EndPoint;

    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }
}

