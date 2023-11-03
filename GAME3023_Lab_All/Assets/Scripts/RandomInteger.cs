using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerEditorScript))]
public class RandomInteger : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerEditorScript PES = (PlayerEditorScript)target;

        if (GUILayout.Button("Add New:"))
        {
            ExampleWindow win = (ExampleWindow)EditorWindow.GetWindow(typeof(ExampleWindow), false, "ADD");
            win.Show();
        }
    }
}
