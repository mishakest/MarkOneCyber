using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackProcessor))]
public class TrackProcessorTools : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var processor = (TrackProcessor)target;

        if (GUILayout.Button("Spawn New Chunk"))
        {
            processor.AddChunk();
        }
    }
}
