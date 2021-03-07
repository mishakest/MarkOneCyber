using MarkOne.Factory;
using MarkOne.Pool;
using Obstacles.MoveableObstacles;
using UnityEngine;

namespace Obstacles.Pools
{
    [CreateAssetMenu(menuName = "Pool/Trams Pool")]
    public class TramPoolSO : ComponentPoolSO<Tram>
    {
        [SerializeField] private TramFactorySO _factory = default;

        public override IFactory<Tram> Factory
        {
            get => _factory;
            set => _factory = value as TramFactorySO;
        }
    }
}
