using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

[RequireComponent(typeof(Protagonist))]
public class ProtagonsistCollision : MonoBehaviour
{
    private Protagonist _protagonist;

    private void Start()
    {
        _protagonist = GetComponent<Protagonist>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.HandleComponent<Obstacle>(component =>
        {
            _protagonist.Die();
        });
    }
}
