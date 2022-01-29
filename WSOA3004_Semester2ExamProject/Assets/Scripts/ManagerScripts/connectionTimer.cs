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
    public GameObject GameUI;

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

            /*if (continuedSeperationTime >= 12)
            {
                //Play Sound
                FindObjectOfType<MusicManager>().Play("Warning");
            }*/

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
            FindObjectOfType<MusicManager>().Play("Connected");
        }
    }



    IEnumerator waitBeforeDeactivate()
    {
        yield return new WaitForSeconds(1f);

        EndPanel.SetActive(true);

        //Play Sound
        FindObjectOfType<MusicManager>().Play("Fail");

        GameUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
}

   
