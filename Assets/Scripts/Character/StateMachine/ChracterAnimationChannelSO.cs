using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Protagonist/ChracterAnimationChannel")]
public class ChracterAnimationChannelSO : ScriptableObject
{
    public event UnityAction OnAnimationEnded;

    public void RaiseEvent()
    {
        if (OnAnimationEnded != null)
            OnAnimationEnded.Invoke();
        else
        {
            Debug.LogWarning("Animation Ended event was raised, but nobody picked it up." +
                "Check why there is no Protagonist already present, " +
                "and make sure it's listening on this Charcater Animation channel.");
        }
    }
}