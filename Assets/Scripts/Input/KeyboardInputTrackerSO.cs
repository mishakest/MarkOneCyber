using UnityEngine;
using UnityEngine.Events;

namespace MarkOne.Input
{
    [CreateAssetMenu(fileName = "KeyboardInputTracker", menuName = "Input/Trackers/KeyboardInputTracker")]
    public class KeyboardInputTrackerSO : InputTracker
    {
        public override void TrackInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                SendData(SwipeDirection.Left);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                SendData(SwipeDirection.Right);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                SendData(SwipeDirection.Up);
            else if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                SendData(SwipeDirection.Down);
        }
    }
}