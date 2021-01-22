using UnityEngine;

public class SwipeInputSender : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader = default;

    [SerializeField] private SwipeInputDetector _inputDetector = default;
    [SerializeField] private SwipeLogger _loggger = default;

    [SerializeField] private bool _enableSwipeLogging = true;
}