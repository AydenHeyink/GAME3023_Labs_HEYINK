using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Item
{
    private string name;
    private int damage;
    private int stamina;

    public Item(string name, int dam, int stam)
    {
        this.name = name;
        this.damage= dam;
        this.stamina= stam;
    }

    public string GetName()
    {
        return name;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetStamina() 
    {
        return stamina;
    }

    public int Use()
    {
        return damage;
    }
}



public class EncounterManager : MonoBehaviour
{
    [SerializeField] Canvas buttonCanvas;
    [SerializeField] GameObject butPref;

    static List<Item> myitem = new List<Item>();

    static bool playerTurn;

    // Start is called before the first frame update
    private void Awake()
    {
        AddNewAbility("Sword", 50, 10);
        AddNewAbility("Dagger", 30, 5);
        AddNewAbility("Fists", 10, 3);
        AddNewAbility("Throwing Knives", 10, 2);
    }

    public Canvas GetCanvas()
    {
        return buttonCanvas;
    }

    void Start()
    {
        playerTurn = true;

        SceneManager.SetActiveScene(SceneManager.GetActiveScene());

        foreach (Item it in myitem) 
        {
            GameObject button = Instantiate(butPref) as GameObject;
            button.transform.SetParent(GetCanvas().transform, false);
            button.gameObject.GetComponentInChildren<Text>().text = it.GetName();
            gameObject.SetActive(true);
        }
    }

    static public void AddNewAbility(string name, int dam, int stam)
    {
        myitem.Add(new Item(name, dam, stam));
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
