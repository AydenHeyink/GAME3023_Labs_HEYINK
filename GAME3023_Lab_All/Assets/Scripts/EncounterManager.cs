using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    List<Button> moves = new List<Button>();
    List<string> names = new List<string>();

    static bool playerTurn;

    [SerializeField] Button but1;
    [SerializeField] Button but2;
    [SerializeField] Button but3;
    [SerializeField] Button but4;
    [SerializeField] Button but5;
    [SerializeField] Button but6;
    [SerializeField] Button but7;

    // Start is called before the first frame update
    private void Awake()
    {
        names.Add("Sword");
        names.Add("Dagger");
        names.Add("Fists");
        names.Add("Throwing Knives");
        names.Add("Ability1");
        names.Add("Ability3");
        names.Add("Ability2");

        moves.Add(but1);
        moves.Add(but2);
        moves.Add(but3);
        moves.Add(but4);
        moves.Add(but5);
        moves.Add(but6);
        moves.Add(but7);
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
