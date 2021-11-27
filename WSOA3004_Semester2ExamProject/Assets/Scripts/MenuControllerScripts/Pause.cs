using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool paused = false;
    public GameObject pausePanel;
    public GameObject GameUI;
    


    private void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Method_Pause();
        }
    }

    public void Method_Pause()
    {
        if (paused)
        {
            paused = false;
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            
        }
        else
        {
            paused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            GameUI.SetActive(false);
            
        }
    }
}
