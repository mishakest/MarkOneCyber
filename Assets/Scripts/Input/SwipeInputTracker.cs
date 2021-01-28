using UnityEngine;
using UnityEngine.EventSystems;

namespace MarkOne.Input
{
    public class SwipeInputTracker : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField] private SwipeInputTrackerSO _tracker = default;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _tracker.OnBeginDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData) { }
    }
}