using MarkOne.Factory;
using Obstacles.MoveableObstacles;
using UnityEngine;

namespace Obstacles.Pools
{
    [CreateAssetMenu(menuName = "Factory/Trams Factory")]
    public class TramFactorySO : FactorySO<Tram>
    {
        [SerializeField] private Tram _tramPrefab = default;

        public override Tram Create()
        {
            return Instantiate(_tramPrefab);
        }
    }
}
