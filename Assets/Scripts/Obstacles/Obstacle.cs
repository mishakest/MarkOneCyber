using System.Collections;
using System.Collections.Generic;
using MarkOne.Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour, IHitable
{
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Hit()
    {
        
    }
}
