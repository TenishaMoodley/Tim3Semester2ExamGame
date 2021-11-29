using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class connectionTimer : MonoBehaviour
{
    public Slider TimerSlider;
    // public TMP_Text TimerText;
    public float maxSeparationTime;
    
    public float continuedSeperationTime;

    public General g;
    public Manager m;
    public bool stopTimer;
    public bool isTiming;
    public GameObject EndPanel;

    private float timeAtDisconnection;

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
        if (!stopTimer)
        {

            continuedSeperationTime += Time.deltaTime;
            Debug.Log(continuedSeperationTime);

            TimerSlider.value = maxSeparationTime - continuedSeperationTime;                                                                


            if (continuedSeperationTime >= maxSeparationTime)
            {
                stopTimer = true;

                StartCoroutine(waitBeforeDeactivate());

            }

        }

    }

    public void ResetConnectionTimer()
    {
        if ( stopTimer )
        {
            timeAtDisconnection = Time.timeSinceLevelLoad;
            stopTimer = false;
        }
    }



    IEnumerator waitBeforeDeactivate()
    {
        yield return new WaitForSeconds(1f);

        EndPanel.SetActive(true);
    }
}

   
