using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class destroyObject : MonoBehaviour
{
    public Slider TimerSlider;
    public TMP_Text TimerText;
    public float CollectableTime;
    public float defaultTime;

    private bool stopTimer;

    void Start()
    {
        CollectableTime = defaultTime;
        stopTimer = false;
        TimerSlider.maxValue = CollectableTime;
        TimerSlider.value = CollectableTime;
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
            gameObject.SetActive(false);
        }
        if (stopTimer == false)
        {
            TimerText.text = TextTime;
            TimerSlider.value = timeRN;
        }

    }
}
