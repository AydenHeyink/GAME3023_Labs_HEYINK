using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource source;

    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip encounterMusic;


    // Start is called before the first frame update
    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;


        switch (scene) 
        {
            case "SampleScene":
                source.clip= gameMusic; 
                source.Play();
                break;
            case "StartScene":
                source.clip = menuMusic;
                source.Play();
                break;
            case "EncounterScene":
                source.clip = encounterMusic;
                source.Play();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
