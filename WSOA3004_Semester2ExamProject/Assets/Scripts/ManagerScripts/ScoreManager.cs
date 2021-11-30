using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text highscoreText;
    public float highscoreCounter;
    public Manager m;
    public TimerCount t;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreCounter = PlayerPrefs.GetFloat("Highscore");
        }
    }

    private void Update()
    {
        if (m.score > highscoreCounter) //highscore
        {
            highscoreCounter = m.score;
            PlayerPrefs.SetFloat("Highscore", highscoreCounter);
        }

        highscoreText.text = "Fastest Time: " + Mathf.Round(highscoreCounter);
    }
     

}
