using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private FuctionTimer functiontimer; 
    private void Start()
    {
       functiontimer = new FuctionTimer(TestingAction, 3f); // action that  will  be triggered. Fucntion is called from the functiontimer script / adding "functiontimer  =" allowes funtion to be run in the  update 
    }

    private void Update()
    {
        functiontimer.Update();
    }
     
    private void TestingAction() 
    {
        Debug.Log("Test");
    
    }
}
