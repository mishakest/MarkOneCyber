using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] private ChracterAnimationChannelSO _animationChannel = default;

    public void OnAnimationEnded()
    {
        _animationChannel.RaiseEvent();
    }
}