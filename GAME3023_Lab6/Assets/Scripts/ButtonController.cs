using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1Pressed()
    {
        Debug.Log("Sword Used!");

        EnemyManager.DamageEnemy(45);
        EncounterManager.Turn();
    }

    public void Button2Pressed()
    {
        Debug.Log("Dagger Used!");

        EnemyManager.DamageEnemy(20);
        EncounterManager.Turn();
    }

    public void Button3Pressed()
    {
        Debug.Log("Fists Used!");

        EnemyManager.DamageEnemy(5);
        EncounterManager.Turn();
    }

    public void Button4Pressed()
    {
        Debug.Log("Throwing Knives Used!");

        EnemyManager.DamageEnemy(15);
        EncounterManager.Turn();
    }

    public void Button5Pressed()
    {
        Debug.Log("Steal Ability Used!");

        PlayerBehaviour.HealPlayer(30);
        EnemyManager.DamageEnemy(15);
        EncounterManager.Turn();
    }

    public void Button6Pressed()
    {
        Debug.Log("Health Increase Used!");

        PlayerBehaviour.HealPlayer(50);
        EncounterManager.Turn();
    }

    public void Button7Pressed()
    {
        Debug.Log("Knock Out Used!");
     
        EncounterManager.Turn();
    }
}
