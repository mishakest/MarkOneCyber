using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Protagonist Event Channel")]
public class ProtagonistStatusEventChannelSO : ScriptableObject
{
    public event UnityAction<ProtagonistStatusSO> OnDataChangeRequest;

    public void RaiseEvent(ProtagonistStatusSO protagonistData)
    {
        if (OnDataChangeRequest != null)
        {
            OnDataChangeRequest.Invoke(protagonistData);
        }
        else
        {
            Debug.LogWarning("A protagonist data change was requested, but nobody picked it up." +
               " Make sure it's listening on this Load Event channel.");
        }
    }
}