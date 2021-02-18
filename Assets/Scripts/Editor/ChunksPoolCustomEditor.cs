using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CanEditMultipleObjects]
[CustomEditor(typeof(ChunksPool))]
public class ChunksPoolCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var pool = (ChunksPool)target;

        if (GUILayout.Button("Reload Pool"))
        {
            pool.Reload();
        }
    }
}
