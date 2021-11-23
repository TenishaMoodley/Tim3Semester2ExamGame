using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public connectionTimer ctScript;
    
    public GameObject Line_GO;


        public GameObject Bean1_GO;
        public GameObject Bean2_GO;


    public float Max_Distance;


    private void Update()
    {

        float Distance = Vector3.Distance(Bean1_GO.transform.position, Bean2_GO.transform.position);
        if (Distance > Max_Distance)
        {
            Line_GO.SetActive(false);
            ctScript.TimerSlider.maxValue = ctScript.initialSeperationTime;
            ctScript.TimerSlider.value = ctScript.initialSeperationTime;
              

        }
        else
        {
            Line_GO.SetActive(true);
        }
    }


}
