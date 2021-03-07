using System;
using UnityEngine;

namespace Obstacles.Pools
{
    public class TramPool : MonoBehaviour
    {
        [SerializeField] private TramPoolSO _pool = default;
        [SerializeField] private int _initialSize = 20;

        private void Awake()
        {
            _pool.Prewarm(_initialSize);
            _pool.SetParent(this.transform);
        }
    }
}