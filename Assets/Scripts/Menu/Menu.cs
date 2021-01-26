using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class Menu : MonoBehaviour
{
    [Header("Channel")]
    [SerializeField] private LoadEventChannelSO _loadEventChannel;

    [Header("Locations To Load")]
    [SerializeField] private GameSceneSO[] _locationsToLoad;
    [SerializeField] private bool _enableLoadingScreen = false;

    public void OnPlayButtonClicked()
    {
        _loadEventChannel.RaiseEvent(_locationsToLoad, _enableLoadingScreen);
    }
}
