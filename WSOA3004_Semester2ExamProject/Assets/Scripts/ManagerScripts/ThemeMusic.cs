using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThemeMusic : MonoBehaviour
{
    Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Awake()
    {
        if (currentScene.name == "Menu" && currentScene.name == "Rules")
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
            if (objs.Length > 1)
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
            

       

        /*else if (currentScene.name == "EasyScene 1" || currentScene.name == "EasyScene 2" || currentScene.name == "EasyScene 3")
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
            if (objs.Length > 1)
                Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }*/



    }

    
}
