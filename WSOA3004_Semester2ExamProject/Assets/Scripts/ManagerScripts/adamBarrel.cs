using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adamBarrel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Adam") 
        {
            //this.gameObject.GetComponent<Collider>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().mass = 5f;
            //this.gameObject.GetComponentInParent<Collider>().enabled = false;  
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Adam")
        {
            // this.gameObject.GetComponent<Collider>().enabled = true;
            this.gameObject.GetComponent<Rigidbody>().mass = 1f;
            //this.gameObject.GetComponentInParent<Collider>().enabled = true;
        }

    }
}
