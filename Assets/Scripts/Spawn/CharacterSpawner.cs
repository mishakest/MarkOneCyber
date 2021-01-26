using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterSpawnEventChannelSO _spawnEventChannel = default;

    public ProtagonistSO ProtagonistToSpawn;

    private void OnEnable()
    {
        _spawnEventChannel.OnCharacterSpawnRequest += SpawnCharacter;
    }

    private void OnDisable()
    {
        _spawnEventChannel.OnCharacterSpawnRequest -= SpawnCharacter;
    }

    private void SpawnCharacter(Transform parent)
    {
        Instantiate(ProtagonistToSpawn.ProtagonistPrefab, parent);
    }
}