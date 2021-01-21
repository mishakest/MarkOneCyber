using UnityEngine;
using MarkOne.Factory;

[CreateAssetMenu(fileName = "NewSoundEmitterFactory", menuName = "Factory/SoundEmitter Factory")]
public class SoundEmitterFactorySO : FactorySO<SoundEmitter>
{
    public SoundEmitter SoundEmitterPrefab;

    public override SoundEmitter Create()
    {
        return Instantiate(SoundEmitterPrefab);
    }
}