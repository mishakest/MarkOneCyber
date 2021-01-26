using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Character Spawn Event Channel")]
public class CharacterSpawnEventChannelSO : ScriptableObject
{
    public event UnityAction<Transform> OnCharacterSpawnRequest;

    public void RaiseEvent(Transform parent)
    {
        if (OnCharacterSpawnRequest != null)
        {
            OnCharacterSpawnRequest.Invoke(parent);
        }
        else
        {
            Debug.LogWarning("A Character spawn was requested, but nobody picked it up." +
                            "Check why there is no Protagonist already present, " +
                            "and make sure it's listening on this Character Spawn Event channel.");
        }
    }
}
