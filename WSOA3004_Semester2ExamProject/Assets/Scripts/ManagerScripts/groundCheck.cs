using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{ 
    public bool isGrounded; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "ground")
        {
            isGrounded = false;
            //anim.SetBool("isJumping", false);

        }
    }
}
