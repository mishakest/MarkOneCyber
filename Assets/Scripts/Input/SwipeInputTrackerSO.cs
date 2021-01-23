﻿using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SwipeInputTracker", menuName = "Input/Trackers/SwipeInputTracker")]
public class SwipeInputTrackerSO : InputTracker
{
    [SerializeField] private bool _detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float _minDistanceForSwipe = 20.0f;

    private Vector2 _fingerDownPosition;
    private Vector2 _fingerUpPosition;

    public override void TrackInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerUpPosition = touch.position;
                _fingerDownPosition = touch.position;
            }

            if (!_detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                _fingerDownPosition = touch.position;
                DetectSwipe();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (IsSwipeDistanceCheckMet())
        {
            var deltaPosition = _fingerDownPosition.y - _fingerUpPosition.y;

            if (IsVerticalSwipe())
            {
                var direction = deltaPosition > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = deltaPosition > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }

            _fingerUpPosition = _fingerDownPosition;
        }
    }

    private bool IsSwipeDistanceCheckMet() => GetVerticalMovementDistance() > _minDistanceForSwipe || GetHorizontalMovementDistance() > _minDistanceForSwipe;
    private bool IsVerticalSwipe() => GetVerticalMovementDistance() > GetHorizontalMovementDistance();
    private float GetVerticalMovementDistance() => Mathf.Abs(_fingerDownPosition.y - _fingerUpPosition.y);
    private float GetHorizontalMovementDistance() => Mathf.Abs(_fingerDownPosition.x - _fingerUpPosition.x);

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = _fingerDownPosition,
            EndPosition = _fingerUpPosition
        };
        SendData(swipeData);
    }
}