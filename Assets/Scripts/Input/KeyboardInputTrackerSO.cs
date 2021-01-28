using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "KeyboardInputTracker", menuName = "Input/Trackers/KeyboardInputTracker")]
public class KeyboardInputTrackerSO : InputTracker
{
    public override void TrackInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SendData(SwipeDirection.Left);
        else if (Input.GetKeyDown(KeyCode.D))
            SendData(SwipeDirection.Right);
        else if (Input.GetKeyDown(KeyCode.Space))
            SendData(SwipeDirection.Up);
        else if (Input.GetKeyDown(KeyCode.S))
            SendData(SwipeDirection.Down);
    }
}