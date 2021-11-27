using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAnim2 : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(pAnim2());

    }

    IEnumerator pAnim2()
    {
        yield return new WaitForSeconds(70);
        anim.SetBool("isExpanding", true);
        Debug.Log("The wait is over");


    }
}
