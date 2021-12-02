using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBarrel : MonoBehaviour
{

    public ParticleSystem explosion;
    public GameObject DestroyableWall;


    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            explosion.Play();
            Destroy(collision.gameObject, 0.5f); //destroy barrel
            Destroy(DestroyableWall, 0.5f); //destroy yourself (wall)

            //Play Sound
            FindObjectOfType<MusicManager>().Play("WallBreak");

        }

    }
}
