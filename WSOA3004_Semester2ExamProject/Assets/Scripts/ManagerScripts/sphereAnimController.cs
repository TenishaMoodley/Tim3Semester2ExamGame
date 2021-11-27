using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereAnimController : MonoBehaviour
{
    private Animator anim; 
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(pAnim1());

    }

    IEnumerator pAnim1() 
    {
        yield return new WaitForSeconds(100);
        anim.SetBool("isExpanding", true);
        Debug.Log("The wait is over");
       
    
    }
}
