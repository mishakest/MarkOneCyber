using MarkOne.Interfaces;
using UnityEngine;

public class Coin : MonoBehaviour, IMoveable
{
    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime;
    }
}
