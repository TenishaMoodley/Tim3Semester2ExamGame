using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform linkedPortal;
    public Transform jammoLocation; 
    public Animator PortalAnim;
    public GameObject PortalUI;
    public General generalScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PortalUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Adam") //|| collision.gameObject.tag == "Connection"
        {
            PortalUI.SetActive(true);

            Player_Movement fountain = collision.gameObject.GetComponent<Player_Movement>();
            if (fountain.Teleporting == false)
            {
                fountain.Teleporting = true;
                fountain.transform.position = linkedPortal.position;
                fountain.enteredPortal = gameObject;
                PortalAnim.SetBool("isEntered", true);
            }
        }

        if (collision.gameObject.tag == "Jammo") 
        {
            Player_Movement fountain = collision.gameObject.GetComponent<Player_Movement>();
            if (fountain.Teleporting == false)
            {
                fountain.Teleporting = true;
                fountain.transform.position = jammoLocation.position;
                fountain.enteredPortal = gameObject;
                
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

        if (collision.gameObject.tag == "Jammo") 
        {
            Player_Movement fountain = collision.gameObject.GetComponent<Player_Movement>();
            if (fountain.Teleporting == true && fountain.enteredPortal != gameObject) 
            {
                fountain.Teleporting = false;

                fountain.enteredPortal = null;

            }

        }
    }

}
