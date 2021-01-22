using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "KeyboardInputTracker", menuName = "Input/Trackers/KeyboardInputTracker")]
public class KeyboardInputTrackerSO : InputTracker
{
    public override void TrackInput()
    {
        SwipeDirection direction = default;

        if (Input.GetKeyDown(KeyCode.A))
            direction = SwipeDirection.Left;
        else if (Input.GetKeyDown(KeyCode.D))
            direction = SwipeDirection.Right;
        else if (Input.GetKeyDown(KeyCode.Space))
            direction = SwipeDirection.Up;
        else if (Input.GetKeyDown(KeyCode.S))
            direction = SwipeDirection.Down;

        if(Input.anyKeyDown)
        {
            SendData(direction);
        }
    }

    private void SendData(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction
        };

        SendData(swipeData);
    }
}