using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CharacterCollider : MonoBehaviour
{
    public CapsuleCollider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Start()
    {
        Collider = GetComponent<CapsuleCollider>();
        Rigidbody = GetComponent<Rigidbody>();
    }
}
