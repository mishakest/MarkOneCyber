using UnityEngine;

namespace MarkOne.Input
{
    [CreateAssetMenu(fileName = "InputLogger", menuName = "Input/Input Logger")]
    public class InputLogger : ScriptableObject
    {
        public void Log(InputTracker.SwipeDirection direction)
        {
            Debug.Log($"Input with direction {direction}");
        }
    }
}