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


    private void Update()
    {

        float Distance = Vector3.Distance(Bean1_GO.transform.position, Bean2_GO.transform.position);
        if (Distance > Max_Distance )//far apart from each other    and longer than specific amount of seconds. 
        {
           
            if (time < Time.time)
            {
                Line_GO.SetActive(false);
                ctScript.TimerSlider.maxValue = ctScript.initialSeperationTime;
                ctScript.TimerSlider.value = ctScript.initialSeperationTime;
                ctScript.stopTimer = false;

            }



        }
        else
        {
            Line_GO.SetActive(true);
            ctScript.stopTimer = true;

        }
    }


}
