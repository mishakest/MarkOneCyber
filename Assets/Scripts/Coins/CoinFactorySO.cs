using MarkOne.Factory;
using UnityEngine;

[CreateAssetMenu(menuName = "Factory/Coins Factory")]
public class CoinFactorySO : FactorySO<Coin>
{
    [SerializeField] private Coin _coinPrefab = default;

    public override Coin Create()
    {
        return Instantiate(_coinPrefab);
    }
}
