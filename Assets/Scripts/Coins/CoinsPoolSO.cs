using MarkOne.Factory;
using MarkOne.Pool;
using UnityEngine;

[CreateAssetMenu(menuName = "Pool/Coins Pool")]
public class CoinsPoolSO : ComponentPoolSO<Coin>
{
    [SerializeField] private CoinFactorySO _factory = default;

    public override IFactory<Coin> Factory
    {
        get => _factory;
        set => _factory = value as CoinFactorySO;
    }
}
