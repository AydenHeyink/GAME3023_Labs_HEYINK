using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    static bool playerTurn;

    // Start is called before the first frame update
    private void Awake()
    {
      
    }

    void Start()
    {
        playerTurn = true;

        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // ISSUES---
    static public void EndEncounter()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("EncounterScene");
    }

    static public void Begin(int var)
    {
        Debug.Log(var);
    }

    static public bool GetTurn()
    {
        return playerTurn;
    }
    static public void Turn()
    {
        if (playerTurn)
        {
            playerTurn= false;
            EnemyManager.EnemyTurn();
        }
        else if (!playerTurn)
        {
            playerTurn= true;
        }
    }
}
