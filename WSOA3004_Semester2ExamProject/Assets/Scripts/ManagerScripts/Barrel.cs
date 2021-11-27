using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject BarrelUI;

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Jammo")
        {

            BarrelUI.SetActive(true);

        }
    }
}
