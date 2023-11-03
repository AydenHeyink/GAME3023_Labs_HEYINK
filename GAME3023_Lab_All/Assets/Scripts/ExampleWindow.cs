using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    string nameString_A = "placeholder";
    int damageInt_A = 0;
    int staminaInt_A = 0;

    string nameString_W = "placeholder";
    int damageInt_W = 0;
    int staminaInt_W = 0;

    [MenuItem("Window/Add New Ability OR Weapon")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Add");
    }

    void OnGUI()
    {

        // Block to add new ability
        GUILayout.Label("Ability:", EditorStyles.boldLabel);

        nameString_A = EditorGUILayout.TextField("Name", nameString_A);

        damageInt_A = EditorGUILayout.IntField("Damage", damageInt_A);
        staminaInt_A = EditorGUILayout.IntField("Stamina", staminaInt_A);

        if (GUILayout.Button("Craft New Ability"))
        {
            Debug.Log(nameString_A);
            Debug.Log(damageInt_A);
            Debug.Log(staminaInt_A);
        }


        // Block to add new weapon
        GUILayout.Label("Weapon:", EditorStyles.boldLabel);

        nameString_W = EditorGUILayout.TextField("Name", nameString_W);

        damageInt_W = EditorGUILayout.IntField("Damage", damageInt_W);
        staminaInt_W = EditorGUILayout.IntField("Stamina", staminaInt_W);

        if (GUILayout.Button("Craft New Weapon"))
        {
            Debug.Log(nameString_A);
            Debug.Log(damageInt_W);
            Debug.Log(staminaInt_W);
        }
    }
}
