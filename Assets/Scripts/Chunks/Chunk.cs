using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Bounds")]
    public Transform StartPoint;
    public Transform EndPoint;

    [Header("Ground")]
    public Ground Ground;

    public void Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetSpawnPosition(Vector3 previuosChunkEndPosition) => transform.position = previuosChunkEndPosition - StartPoint.localPosition;
}
