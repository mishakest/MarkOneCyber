using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnLoadHandler : MonoBehaviour
{
    private void Awake() => gameObject.SetActive(false);
}
