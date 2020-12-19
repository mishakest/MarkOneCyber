using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public float MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool SlideInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
            MovementInput = context.ReadValue<float>();
    }

    public void OnSlideInput(InputAction.CallbackContext context)
    {
        if (context.started)
            SlideInput = true;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
            JumpInput = true;
    }

    public void UseJumpInput() => JumpInput = false;
    public void UseSlideInput() => SlideInput = false;
    public void UseMovementInput() => MovementInput = 0.0f;
}
