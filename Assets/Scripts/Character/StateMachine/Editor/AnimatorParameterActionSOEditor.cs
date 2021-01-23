using UnityEngine;
using UnityEditor;
using MarkOne.StateMachine;

[CustomEditor(typeof(AnimatorParameterActionSO)), CanEditMultipleObjects]
public class AnimatorParameterActionSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("WhenToRun"));
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Animator Parammeter", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ParameterName"), new GUIContent("Name"));

        SerializedProperty animatorParameterValue = serializedObject.FindProperty("parameterType");

        EditorGUILayout.PropertyField(animatorParameterValue, new GUIContent("Type"));

        switch (animatorParameterValue.intValue)
        {
            case (int)AnimatorParameterActionSO.ParameterType.Bool:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("BoolValue"), new GUIContent("Desired value"));
                break;
            case (int)AnimatorParameterActionSO.ParameterType.Int:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("IntValue"), new GUIContent("Desired value"));
                break;
            case (int)AnimatorParameterActionSO.ParameterType.Float:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("FloatValue"), new GUIContent("Desired value"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}