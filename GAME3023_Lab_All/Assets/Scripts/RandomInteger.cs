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

        if (GUILayout.Button("Add new Ability"))
        {
        }

        if (GUILayout.Button("Add new weapon"))
        {
        }    
    }
}
