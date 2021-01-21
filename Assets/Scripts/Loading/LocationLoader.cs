using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 0649
public class LocationLoader : MonoBehaviour
{
    [Header("Initialization Scene")]
    [SerializeField] private GameSceneSO _initializationScene;
    [Header("Load on start")]
    [SerializeField] private GameSceneSO[] _mainMenuScenes;
    [Header("Loading Screen")]
    [SerializeField] private GameObject _loadingInterface;
    [SerializeField] private Image _loadingProgressBar;

    [Header("Load Event")]
    [SerializeField] private LoadEventChannelSO _loadEventChannel;

    private List<AsyncOperation> _scenesToLoadAsyncOperation = new List<AsyncOperation>();
    private List<Scene> _scenesToUnload = new List<Scene>();

    private GameSceneSO _activeScene;

    private void OnEnable()
    {
        _loadEventChannel.OnLoadingRequested += LoadScenes;
    }

    private void OnDisable()
    {
        _loadEventChannel.OnLoadingRequested -= LoadScenes;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == _initializationScene.SceneName)
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        LoadScenes(_mainMenuScenes, false);
    }

    private void LoadScenes(GameSceneSO[] locationsToLoad, bool showLoadingScreen)
    {
        AddScenesToUnload();

        _activeScene = locationsToLoad[0];

        for (int i = 0; i < locationsToLoad.Length; ++i)
        {
            var currentSceneName = locationsToLoad[i].SceneName;

            if (!CheckLoadState(currentSceneName))
            {
                _scenesToLoadAsyncOperation.Add(SceneManager.LoadSceneAsync(currentSceneName, LoadSceneMode.Additive));
            }

            _scenesToLoadAsyncOperation[0].completed += SetActiveScene;

            if (showLoadingScreen)
            {
                _loadingInterface.SetActive(true);
                StartCoroutine(TrackLoadingProgress());
            }
            else
            {
                _scenesToLoadAsyncOperation.Clear();
            }
        }

        UnloadScenes();
    }

    private void SetActiveScene(AsyncOperation asyncOperation)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_activeScene.SceneName));
    }

    private void AddScenesToUnload()
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            var scene = SceneManager.GetSceneAt(i);

            if (scene.name != _initializationScene.SceneName)
            {
                Debug.Log("Added scene to unload = " + scene.name);
                _scenesToUnload.Add(scene);
            }
        }
    }

    private void UnloadScenes()
    {
        if (_scenesToUnload != null)
        {
            for (int i = 0; i < _scenesToUnload.Count; ++i)
            {
                SceneManager.UnloadSceneAsync(_scenesToUnload[i]);
            }
        }

        _scenesToUnload.Clear();
    }

    private bool CheckLoadState(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            var scene = SceneManager.GetSceneAt(i);

            if (scene.name == sceneName)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator TrackLoadingProgress()
    {
        float totalProgress = 0.0f;

        while (totalProgress <= 0.9f)
        {
            totalProgress = 0.0f;

            for (int i = 0; i < _scenesToLoadAsyncOperation.Count; ++i)
            {
                Debug.Log($"Scene {i} : {_scenesToLoadAsyncOperation[i].isDone} progress = {_scenesToLoadAsyncOperation[i].progress}");
                totalProgress += _scenesToLoadAsyncOperation[i].progress;
            }

            _loadingProgressBar.fillAmount = totalProgress / _scenesToLoadAsyncOperation.Count;

            Debug.Log($"progress bar {_loadingProgressBar.fillAmount}");
            yield return null;
        }

        _scenesToLoadAsyncOperation.Clear();
        _loadingInterface.SetActive(false);
    }
}