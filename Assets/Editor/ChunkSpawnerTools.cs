using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChunkSpawner))]
public class ChunkSpawnerTools : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var spawner = (ChunkSpawner)target;

        if (GUILayout.Button("Spawn Chunk"))
        {
            spawner.Spawn();
        }
    }
}
