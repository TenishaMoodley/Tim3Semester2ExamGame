using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TimerCount : MonoBehaviour
{
    public float CollectableTime;
    public TMP_Text Timer_Txt_UI;
    public TMP_Text highscoreText;
    public TMP_Text currentScoreText;
    public float highscoreCounter = float.MaxValue;
    public float currentScore;

    public string HIGHSCORE_KEY = "Easy_HighScore";

    private bool stopTimer;

#if UNITY_EDITOR
    [MenuItem("PlayerPrefs Util/Delete ALL PLAYER PREFS KEYS")]
    public static void DeleteHighScore()
    {
        //PlayerPrefs.DeleteKey(HIGHSCORE_KEY);
        PlayerPrefs.DeleteAll();
    }

#endif
    private void Start()
    {
        stopTimer = false;
        highscoreCounter = float.MaxValue;
        if (PlayerPrefs.HasKey(HIGHSCORE_KEY))
        {
            highscoreCounter = PlayerPrefs.GetFloat(HIGHSCORE_KEY);
        }
        else
        {
            PlayerPrefs.SetFloat(HIGHSCORE_KEY, highscoreCounter);
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

        }
        if (stopTimer == false)
        {

            Timer_Txt_UI.text = TextTime;
        }

        //highscore
        currentScore = CollectableTime - timeRN;
       //UpdateHighScore();

        highscoreText.text = Mathf.Round(highscoreCounter) + " s";
        currentScoreText.text = Mathf.Round(currentScore) + " s";

    }

    public void UpdateHighScore()
    {
        if (currentScore < highscoreCounter)
        {
            highscoreCounter = currentScore;
            PlayerPrefs.SetFloat(HIGHSCORE_KEY, highscoreCounter);
        }
    }
}
