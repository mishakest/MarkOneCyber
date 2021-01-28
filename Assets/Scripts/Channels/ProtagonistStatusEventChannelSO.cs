using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Protagonist Event Channel")]
public class ProtagonistStatusEventChannelSO : ScriptableObject
{
    public event UnityAction OnProtagonistDeath;
    public event UnityAction OnProtagonistRevive;

    public void RaiseEvent(bool isDead)
    {
        if (isDead)
            OnProtagonistDeath?.Invoke();
        else
            OnProtagonistRevive?.Invoke();
    }
}