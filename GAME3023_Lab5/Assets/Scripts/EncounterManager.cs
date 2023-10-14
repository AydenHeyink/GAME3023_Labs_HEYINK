using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EncounterManager : MonoBehaviour
{
    List<Button> moves = new List<Button>();
    List<string> names = new List<string>();

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

    TextMeshProUGUI t;
    void Start()
    {
        foreach(string s in names)
        {
            for(int i = 0; i < names.Count; i++)
            {
                //moves[i].GetComponentInChildren<Text>().text= s;
            }
        }


        //but1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(2);
        }
    }

    static public void Begin(int var)
    {
        Debug.Log(var);
    }
}
