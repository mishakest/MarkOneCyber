using UnityEngine;
using SwipeData = InputTracker.SwipeData;

[CreateAssetMenu(fileName = "InputLogger", menuName = "Input/Input Logger")]
public class InputLogger : ScriptableObject
{
    public void Log(SwipeData data)
    {
        Debug.Log($"Input with direction {data.Direction}");
    }
}