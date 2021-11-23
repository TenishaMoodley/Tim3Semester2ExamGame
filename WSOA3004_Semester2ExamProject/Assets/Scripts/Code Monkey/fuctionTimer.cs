using System;  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuctionTimer  
{
    private Action action;
    private float timer;
    private bool isDestroyed; 

    public FuctionTimer(Action action, float timer) // action takes no parameters and returns to void.
    {
        this.action = action;
        this.timer = timer;
        isDestroyed = false; 
    }

    public void Update() 
    {
        if (!isDestroyed) // only runs when object is not  destroyed 
        {
            timer -= Time.deltaTime;  //count down timer.
            if (timer < 0)
            {
                //Trigger action if timer is < 0
                action(); //stored function.
                DestroySelf(); //Destroys self after action has been triggered 
            }

        }
        
    }
    private void DestroySelf() //destroys FunctionTimer  
    {
        isDestroyed = true; 
    } 
   
   
}
