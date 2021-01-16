using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Channel")]
    [SerializeField] private LoadEventChannelSO _loadEventChannel;

    [Header("Locations To Load")]
    [SerializeField] private GameSceneSO[] _locationsToLoad;

    public void OnPlayButtonClicked()
    {
        _loadEventChannel.RaiseEvent(_locationsToLoad, false);
    }
}
