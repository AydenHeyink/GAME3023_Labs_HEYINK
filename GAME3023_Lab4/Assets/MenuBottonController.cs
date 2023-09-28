using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottonController : MonoBehaviour
{
    string levelName1 = "MainGame";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButtonPlay()
    {
        SceneManager.LoadScene(levelName1);
    }

    public void OnClickButtonQuit()
    {
        Application.Quit();
    }
}
