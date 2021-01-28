using UnityEngine;
using UnityEngine.EventSystems;

namespace MarkOne.Input
{
    [CreateAssetMenu(fileName = "SwipeInputTracker", menuName = "Input/Trackers/SwipeInputTracker")]
    public class SwipeInputTrackerSO : InputTracker, IBeginDragHandler, IDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                var direction = eventData.delta.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendData(direction);
            }
            else
            {
                var direction = eventData.delta.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendData(direction);
            }
        }

        public void OnDrag(PointerEventData eventData) { }

        public override void TrackInput() { }
    }
}

