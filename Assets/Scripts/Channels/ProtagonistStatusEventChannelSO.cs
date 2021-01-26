using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Protagonist Event Channel")]
public class ProtagonistStatusEventChannelSO : ScriptableObject
{
    public event UnityAction OnProtagonistDeath;

    public void RaiseEvent()
    {
        if (OnProtagonistDeath != null)
        {
            OnProtagonistDeath.Invoke();
        }
        else
        {
            Debug.LogWarning("A protagonist data change was requested, but nobody picked it up." +
               " Make sure it's listening on this Load Event channel.");
        }
    }
}