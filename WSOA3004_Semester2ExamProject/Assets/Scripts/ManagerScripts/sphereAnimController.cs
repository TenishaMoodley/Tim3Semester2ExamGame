using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereAnimController : MonoBehaviour
{
    private Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(pAnim());

    }

    IEnumerator pAnim() 
    {
        yield return new WaitForSeconds(50);
        anim.SetBool("isExpanding", true);
        Debug.Log("The wait is over");
       
    
    }
}
