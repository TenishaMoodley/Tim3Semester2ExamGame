using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp2 : MonoBehaviour
{
    
    public Transform destination;
    public GameObject BarrelUI;

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            BarrelUI.SetActive(false);
        }
    }

    
    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Jammo" ) 
        {
            Debug.Log("contact");
            //Input.GetKey(KeyCode.E)

            BarrelUI.SetActive(true);
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = destination.position;
            this.transform.parent = GameObject.Find("pickedUp").transform;
        }
    }
}
