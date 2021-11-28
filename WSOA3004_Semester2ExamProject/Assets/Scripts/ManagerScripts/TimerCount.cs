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
    private bool stopTimer;

    private void Start()
    {
        stopTimer = false;
    }

    private void Update()
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
    }
}
