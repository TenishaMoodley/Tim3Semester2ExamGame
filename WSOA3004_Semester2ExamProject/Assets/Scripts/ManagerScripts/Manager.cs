using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public int score;
    public TMP_Text Score_Txt_End;
    public TMP_Text Score_Txt_UI;
    public GameObject ArrowUI;
    public GameObject WASDUI;

    private int Total = 8;
    private int Destroyed;

    public GameObject EndPanel;

    private void Start()
    {
        EndPanel.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        Destroyed = 0;
    }
    public void Addpoint()
    {
        score++;
    }
    public void DestroyedAdd()
    {
        Destroyed++;
    }

    private void Update()
    {
        Score_Txt_UI.text = "Score: "+score;
        Score_Txt_End.text = "Score: " + score;

        if ((score+Destroyed)==Total)
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

       
        
        
        
        //The game controls UI disappearing after interacted with
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ArrowUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            WASDUI.SetActive(false);
        }
    }
}
