using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCount : MonoBehaviour
{
    public float CollectableTime;
    //public TMP_Text Timer_Txt_End;
    public TMP_Text Timer_Txt_UI;
    public TMP_Text highscoreText;
    public TMP_Text currentScoreText;
    public float highscoreCounter;
    public float currentScore;

    private bool stopTimer;

    private void Start()
    {
        stopTimer = false;

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreCounter = PlayerPrefs.GetFloat("Highscore");
            
        }
    }

    public void Update()
    {
        float timeRN = CollectableTime - Time.timeSinceLevelLoad;
        int minutes = Mathf.FloorToInt(timeRN / 60);
        int seconds = Mathf.FloorToInt(timeRN - minutes * 60);

        string TextTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (timeRN <= 0)
        {
            stopTimer = true;
            
            //Timer_Txt_End.text = TextTime;
        }
        if (stopTimer == false)
        {
            
            Timer_Txt_UI.text = TextTime;
        }

        currentScore = CollectableTime - timeRN;
        

        if (currentScore > highscoreCounter) //highscore
        {
            highscoreCounter = currentScore;
            PlayerPrefs.SetFloat("Highscore", highscoreCounter);
        }

         if (highscoreCounter >= 60)
         {
             
             highscoreText.text = Mathf.Round(highscoreCounter) + " mins";
         }
         else if(highscoreCounter < 60)
         {
            
            highscoreText.text = Mathf.Round(highscoreCounter) + " s";
         }

         
        if (currentScore >= 60)
        {
            currentScoreText.text = Mathf.Round(currentScore) + " mins";
        }
        else if (currentScore < 60)
        {
            currentScoreText.text = Mathf.Round(currentScore) + " s";
        }

    }
}
