using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderEditorWindow : EditorWindow
{
    private GameSceneSO _initScene = default;
    private Scene _loadedScene;

    private const string INIT_SCENE_PATH = "Assets/Scenes/Initialization.unity";

    [MenuItem("Window/Scene Loader")]
    public static void ShowWindow()
    {
        GetWindow<SceneLoaderEditorWindow>("Scene Loader");
    }

    private void OnGUI()
    {
        GUILayout.Box("Scene Management", EditorStyles.boldLabel);
        _initScene = EditorGUILayout.ObjectField("Init Scene", _initScene, typeof(GameSceneSO), false) as GameSceneSO;

        if (GUILayout.Button("Load Init Scene"))
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                SceneManager.LoadSceneAsync(_initScene.Scene.name, LoadSceneMode.Additive);
            else
                _loadedScene = EditorSceneManager.OpenScene(INIT_SCENE_PATH, OpenSceneMode.Additive);
        }

        if (GUILayout.Button("Unload Init Scene"))
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                SceneManager.UnloadSceneAsync(_initScene.Scene.name);
            else
                EditorSceneManager.CloseScene(_loadedScene, true);
        }
    }
}