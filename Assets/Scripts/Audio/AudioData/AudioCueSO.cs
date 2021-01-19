using UnityEngine;

[CreateAssetMenu(fileName = "newAudioCue", menuName = "Audio/Audio Cue")]
public class AudioCueSO : ScriptableObject
{
    public bool IsLooping = false;
    [SerializeField] private AudioClipsGroup[] _audioClipGroups;

    public AudioClip[] GetClips()
    {
        var numberOfClips = _audioClipGroups.Length;
        AudioClip[] resultingClips = new AudioClip[numberOfClips];

        for (int i = 0; i < numberOfClips; i++)
        {
            resultingClips[i] = _audioClipGroups[i].GetNextClip();
        }

        return resultingClips;
    }
}