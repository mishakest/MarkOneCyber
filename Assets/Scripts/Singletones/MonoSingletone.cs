using UnityEngine;

public abstract class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Some of your Mono Singletones is null.");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this as T;
    }

}
