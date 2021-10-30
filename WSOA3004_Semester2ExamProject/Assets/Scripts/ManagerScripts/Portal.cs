using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform linkedPortal;
    public Animator PortalAnim;

   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Adam")
        {
            Player_Movement fountain = collision.gameObject.GetComponent<Player_Movement>();
            if (fountain.Teleporting == false)
            {
                fountain.Teleporting = true;
                fountain.transform.position = linkedPortal.position;
                fountain.enteredPortal = gameObject;
                PortalAnim.SetBool("isEntered", true);
            }

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Adam")
        {
            Player_Movement fountain = collision.gameObject.GetComponent<Player_Movement>();
            if (fountain.Teleporting == true && fountain.enteredPortal != gameObject)
            {
                fountain.Teleporting = false;

                fountain.enteredPortal = null;

                PortalAnim.SetBool("isEntered", false);
            }

        }
    }

}
