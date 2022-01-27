using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class General : MonoBehaviour
{
    public connectionTimer ctScript;
    
    public GameObject Line_GO;


    public GameObject Bean1_GO;
    public GameObject Bean2_GO;

    //Timer Additions//
    float time, waitingTime = 10;

    public float Max_Distance;

    public bool isApart = false;
   


    private void Update()
    {

        float Distance = Vector3.Distance(Bean1_GO.transform.position, Bean2_GO.transform.position);
        if (Distance > Max_Distance)//far apart from each other    and longer than specific amount of seconds. 
        {
            isApart = true;

            if (time < Time.time)
            {
                Line_GO.SetActive(false);
                ctScript.ResetConnectionTimer();
                ctScript.TimerSlider.maxValue = ctScript.maxSeparationTime;
                ctScript.TimerSlider.value = ctScript.maxSeparationTime;
                ctScript.stopTimer = false;

            }


            //Play Sound
            //FindObjectOfType<MusicManager>().Play("Connected");
            
           playSound();
        }
        else
        {
            Line_GO.SetActive(true);
            ctScript.stopTimer = true;


        }
    }

    void playSound() 
    {
        if (isApart) 
        {
            FindObjectOfType<MusicManager>().Play("Connected");
        }
    }


  

}
