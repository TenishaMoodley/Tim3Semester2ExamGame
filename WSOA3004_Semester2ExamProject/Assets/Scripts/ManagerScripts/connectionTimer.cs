using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class connectionTimer : MonoBehaviour
{
    public Slider TimerSlider;
    // public TMP_Text TimerText;
    public float initialSeperationTime;
    public float continuedSeperationTime;
    public General g;
    public Manager m;
    public bool stopTimer;
    public GameObject EndPanel;

    void Start()
    {
        EndPanel.SetActive(false);
        TimerSlider.value = 0;
        //CollectableTime = defaultTime;

        stopTimer = false;
        TimerSlider.maxValue = 0;
        //TimerSlider.value = initialSeperationTime;
    }

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float timeRN = initialSeperationTime - Time.timeSinceLevelLoad; // Time.time cant be reset. 
        int minutes = Mathf.FloorToInt(timeRN / 60);
        int seconds = Mathf.FloorToInt(timeRN - minutes * 60);

        string TextTime = string.Format("{0:0}:{1:00}", minutes, seconds);


        if (timeRN <= 0)
        {
            stopTimer = true;
            //gameObject.SetActive(false);

           /*if (m.score > 0)
            {
                m.score--;
                Debug.Log("score minuesed");
            }*/

            StartCoroutine(waitBeforeDeactivate());

        }

        if (stopTimer == false)
        {
            TimerSlider.value = timeRN;

        }
       
    }

    IEnumerator waitBeforeDeactivate()
    {
        yield return new WaitForSeconds(1f);

        //gameObject.SetActive(false);
        EndPanel.SetActive(true);
    }
}

   
