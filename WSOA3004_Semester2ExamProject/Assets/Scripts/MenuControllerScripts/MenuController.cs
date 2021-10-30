using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void ExitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void Change_Scene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
