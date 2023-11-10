using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

public class ExampleWindow : EditorWindow
{
    string nameString_W = "placeholder";
    int damageInt_W = 0;
    int staminaInt_W = 0;

    [MenuItem("Window/Add New Weapon")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Add");
    }

    void OnGUI()
    {
        // Block to add new weapon
        GUILayout.Label("Weapon:", EditorStyles.boldLabel);

        nameString_W = EditorGUILayout.TextField("Name", nameString_W);

        damageInt_W = EditorGUILayout.IntField("Damage", damageInt_W);
        staminaInt_W = EditorGUILayout.IntField("Stamina", staminaInt_W);

        if (GUILayout.Button("Craft New Weapon"))
        {
            PlayerBehaviour.AddNew(nameString_W, damageInt_W, staminaInt_W);
        }
    }
}
