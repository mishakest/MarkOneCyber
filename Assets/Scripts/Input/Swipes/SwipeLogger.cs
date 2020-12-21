﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private void OnEnable()
    {
        SwipeDetector.OnSwipe += DebugSwipe;
    }

    private void DebugSwipe(SwipeData data)
    {
        Debug.Log("Swipe in direction : " + data.Direction);
    }
}