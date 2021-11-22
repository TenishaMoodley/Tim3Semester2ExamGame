using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class connectionTimer : MonoBehaviour
{
    public Slider TimerSlider;
   // public TMP_Text TimerText;
    public float seperationTime;
    

    private bool stopTimer;

    void Start()
    {
        //CollectableTime = defaultTime;
        //stopTimer = false;
        TimerSlider.maxValue = seperationTime;
        TimerSlider.value = seperationTime;
    }

    private void Update()
    {
        float timeRN = seperationTime - Time.time;
        int minutes = Mathf.FloorToInt(timeRN / 60);
        int seconds = Mathf.FloorToInt(timeRN - minutes * 60);

        string TextTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (timeRN <= 0)
        {
            // stopTimer = true;
            timeRN = seperationTime;
            TimerSlider.value = timeRN;
            //gameObject.SetActive(false);
        }
        if (stopTimer == false)
        {
            //TimerText.text = TextTime;
            TimerSlider.value = timeRN;

        }

    }

    void timer() 
    {
       
       
    }
}
