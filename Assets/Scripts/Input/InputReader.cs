using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject
{
    public event UnityAction<MoveDirection> moveEvent = delegate { };
    public event UnityAction jumpEvent = delegate { };
    public event UnityAction slideEvent = delegate { };

    public enum MoveDirection
    {
        Left = -1,
        Right = 1
    }
}
