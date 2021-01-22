using UnityEngine;
using UnityEngine.Events;

public abstract class InputTracker : ScriptableObject
{
    public event UnityAction<SwipeData> OnInput = delegate { };
    public abstract void TrackInput();

    protected void SendData(SwipeData data) => OnInput?.Invoke(data);

    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public SwipeDirection Direction;
    }
}