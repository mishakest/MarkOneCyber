using UnityEngine;

public class CoinsPool : MonoBehaviour
{
    [SerializeField] private CoinsPoolSO _pool = default;
    [SerializeField] private int _initialSize = 1;

    private void Awake()
    {
        _pool.Prewarm(_initialSize);
        _pool.SetParent(this.transform);
    }
}