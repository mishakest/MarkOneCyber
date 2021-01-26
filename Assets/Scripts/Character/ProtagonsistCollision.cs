using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class ProtagonsistCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.HandleComponent<Obstacle>(component => Destroy(this.gameObject));
    }
}
