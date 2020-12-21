using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwipeDetector : MonoBehaviour
{
    public static event Action<SwipeData> OnSwipe;

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float minDistanceForSwipe = 20.0f;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (IsSwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }

            fingerUpPosition = fingerDownPosition;
        }
    }

    private bool IsSwipeDistanceCheckMet() => GetVerticalMovementDistance() > minDistanceForSwipe || GetHorizontalMovementDistance() > minDistanceForSwipe;
    private bool IsVerticalSwipe() => GetVerticalMovementDistance() > GetHorizontalMovementDistance();
    private float GetVerticalMovementDistance() => Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    private float GetHorizontalMovementDistance() => Mathf.Abs(fingerDownPosition.x = fingerUpPosition.x);

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        OnSwipe(swipeData);
    }
}
