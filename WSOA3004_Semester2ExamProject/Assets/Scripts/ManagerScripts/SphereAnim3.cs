using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAnim3 : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(pAnim3());

    }

    IEnumerator pAnim3()
    {
        yield return new WaitForSeconds(120);
        anim.SetBool("isExpanding", true);
        Debug.Log("The wait is over");


    }
}
