using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour
{
    public ParticleSystem explosion;

    void Start()
    {
       // explosion = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wallBreak")
        {
            explosion.Play();
        }


    }
   

    // explosion.Play();


}
