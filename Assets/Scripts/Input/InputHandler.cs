using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public int MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool SlideInput { get; private set; }

    private void OnEnable()
    {
        SwipeDetector.OnSwipe += HandleMobileInput;
    }

    private void OnDisable()
    {
        SwipeDetector.OnSwipe -= HandleMobileInput;
    }

    private void Update()
    {
#if UNITY_EDITOR
        HandleKeyboardInput();
#endif
    }

    private void HandleMobileInput(SwipeData data)
    {
        switch (data.Direction)
        {
            case SwipeDirection.Up:
                JumpInput = true;
                break;
            case SwipeDirection.Down:
                SlideInput = true;
                break;
            case SwipeDirection.Left:
                MovementInput = -1;
                break;
            case SwipeDirection.Right:
                MovementInput = 1;
                break;
        }
    }

    private void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovementInput = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovementInput = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SlideInput = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;
    public void UseSlideInput() => SlideInput = false;
    public void UseMovementInput() => MovementInput = 0;
}
