using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
     private void Start()
    {
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void Change_Scene(int level)
    {
        SceneManager.LoadScene(level);
        
    }

    public void NextEasyScene()
    {
        EasySceneAdvance.Instance.LoadNextScene();
    }

    public void NextNormalScene()
    {
        NormalSceneAdvance.Instance.LoadNextScene();
    }

    public void NextHardScene()
    {
        HardSceneAdvance.Instance.LoadNextScene();
    }

}
