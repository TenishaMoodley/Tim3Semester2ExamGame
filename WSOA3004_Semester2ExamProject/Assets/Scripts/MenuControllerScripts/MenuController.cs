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

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
    }

    public void Change_Scene(int level)
    {
        SceneManager.LoadScene(level);

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");

    }

    public void NextEasyScene()
    {
        EasySceneAdvance.Instance.LoadNextScene();

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
    }

    public void NextNormalScene()
    {
        NormalSceneAdvance.Instance.LoadNextScene();

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
    }

    public void NextHardScene()
    {
        HardSceneAdvance.Instance.LoadNextScene();

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
    }

}
