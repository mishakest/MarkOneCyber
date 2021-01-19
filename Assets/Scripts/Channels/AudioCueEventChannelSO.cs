using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/AudioCue Event Channel")]
public class AudioCueEventChannelSO : ScriptableObject
{
    public UnityAction<AudioCueSO, AudioConfigurationSO, Vector3> OnAudioCueRequested;

    public void RaiseEvent(AudioCueSO audioCue, AudioConfigurationSO audioConfiguration, Vector3 positionInSpace = default)
    {
		if (OnAudioCueRequested != null)
		{
			OnAudioCueRequested.Invoke(audioCue, audioConfiguration, positionInSpace);
		}
		else
		{
			Debug.LogWarning("An AudioCue was requested, but nobody picked it up. " +
				"Check why there is no AudioManager already loaded, " +
				"and make sure it's listening on this AudioCue Event channel.");
		}
	}
}