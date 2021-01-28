using UnityEngine;
using MoveDirection = InputReader.MoveDirection;
using SwipeData = InputTracker.SwipeData;

public class InputSender : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader = default;
    [SerializeField] private InputTracker _inputTracker = default;
    [SerializeField] private InputLogger _logger = default;

    [SerializeField] private bool _enableLogging = false;

    private void OnEnable()
    {
        _inputTracker.OnInput += SendInput;
    }

    private void OnDisable()
    {
        _inputTracker.OnInput -= SendInput;
    }

    private void Update()
    {
        _inputTracker.TrackInput();
    }

    private void SendInput(SwipeData data)
    {
        switch (data.Direction)
        {
            case InputTracker.SwipeDirection.Up:
                _inputReader.InvokeJumpEvent();
                break;
            case InputTracker.SwipeDirection.Down:
                _inputReader.InvokeSlideEvent();
                break;
            case InputTracker.SwipeDirection.Left:
                _inputReader.InvokeMoveEvent(MoveDirection.Left);
                break;
            case InputTracker.SwipeDirection.Right:
                _inputReader.InvokeMoveEvent(MoveDirection.Right);
                break;
        }

        if (_enableLogging)
            _logger.Log(data);
    }
}