using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
     private void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
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
        AudioListener.pause = false;

    }

    public void NextEasyScene()
    {
        EasySceneAdvance.Instance.LoadNextScene();

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
        AudioListener.pause = false;
    }

    public void NextNormalScene()
    {
        NormalSceneAdvance.Instance.LoadNextScene();

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
        AudioListener.pause = false;
    }

    public void NextHardScene()
    {
        HardSceneAdvance.Instance.LoadNextScene();

        //Play Sound
        FindObjectOfType<MusicManager>().Play("ButtonOrPopup1");
        AudioListener.pause = false;
    }

    /*public void SoundOff()
    {
        AudioListener.pause = true;
    }

    public void SoundOn()
    {
        AudioListener.pause = false;
    }*/

}
