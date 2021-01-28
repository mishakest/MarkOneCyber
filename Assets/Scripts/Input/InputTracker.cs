using UnityEngine;
using UnityEngine.Events;

public abstract class InputTracker : ScriptableObject
{
    public event UnityAction<SwipeDirection> OnInput = delegate { };
    public abstract void TrackInput();

    protected void SendData(SwipeDirection direction) => OnInput?.Invoke(direction);

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}