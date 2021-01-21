using UnityEngine;
using UnityEngine.Audio;

#pragma warning disable 0649
public class AudioProcessor : MonoBehaviour
{
    [Header("SoundEmitters pool")]
    [SerializeField] private SoundEmitterFactorySO _factory;
    [SerializeField] private SoundEmitterPoolSO _pool;
    [SerializeField] private int _initialSize = 10;

    [Header("Listening on channels")]
    [Tooltip("The SoundManager listens to this event, fired by objects in any scene, to play SFXs")]
    [SerializeField] private AudioCueEventChannelSO _SFXEventChannel;
    [Tooltip("The SoundManager listens to this event, fired by objects in any scene, to play Music")]
    [SerializeField] private AudioCueEventChannelSO _musicEventChannel;

    [Header("Audio Control")]
    [SerializeField] private AudioMixer _audioMixer;
    [Range(0f, 1f)]
    [SerializeField] private float _masterVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _musicVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _sfxVolume = 1f;

    private void Awake()
    {
        _SFXEventChannel.OnAudioCueRequested += PlayAudioCue;
        _musicEventChannel.OnAudioCueRequested += PlayAudioCue;

        _pool.Prewarm(_initialSize);
        _pool.SetParent(this.transform);
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            SetGroupVolume("MasterVolume", _masterVolume);
            SetGroupVolume("MusicVolume", _musicVolume);
            SetGroupVolume("SFXVolume", _sfxVolume);
        }
    }

    public void SetGroupVolume(string parameterName, float normalizedVolume)
    {
        bool volumeSet = _audioMixer.SetFloat(parameterName, NormalizedToMixerValue(normalizedVolume));

        if (!volumeSet)
        {
            Debug.LogError("The AudioMixer parameter was not found");
        }
    }

    public float GetGroupVolume(string parameterName)
    {
        if (_audioMixer.GetFloat((parameterName), out float rawVolume))
        {
            return MixerValueToNormalized(rawVolume);
        }
        else
        {
            Debug.LogError("The AudioMixer parameter was not found");
            return 0f;
        }
    }

    public void PlayAudioCue(AudioCueSO audioCue, AudioConfigurationSO settings, Vector3 position = default)
    {
        AudioClip[] clipsToPlay = audioCue.GetClips();
        var amountOfClips = clipsToPlay.Length;

        for (int i = 0; i < amountOfClips; i++)
        {
            SoundEmitter soundEmitter = _pool.Request();

            if (soundEmitter != null)
            {
                soundEmitter.PlayAudioClip(clipsToPlay[i], settings, audioCue.IsLooping, position);

                if (!audioCue.IsLooping)
                {
                    soundEmitter.OnSoundFinishedPlaying += OnSoundEmitterFinishedPlaying;
                }
            }
        }
    }

    private float NormalizedToMixerValue(float normalizedValue)
    {
        return (normalizedValue - 1f) * 80f;
    }
    private float MixerValueToNormalized(float mixerValue)
    {
        return 1f + (mixerValue / 80f);
    }

    private void OnSoundEmitterFinishedPlaying(SoundEmitter soundEmitter)
    {
        soundEmitter.OnSoundFinishedPlaying -= OnSoundEmitterFinishedPlaying;
        soundEmitter.Stop();
        _pool.Return(soundEmitter);
    }
}