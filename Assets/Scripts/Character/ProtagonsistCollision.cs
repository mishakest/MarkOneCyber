using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonsistCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void HandleComponent<T>(GameObject gameObject, Action<T> handler)
    {
        var component = gameObject.GetComponent<T>();

        if (component != null)
            handler?.Invoke(component);
    }
}
