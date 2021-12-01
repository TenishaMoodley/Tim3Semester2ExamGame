using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    GameObject pressurePoint1;
    GameObject pressurePoint2;
    public int switchCount;
    //public Rigidbody Jammo;
    public Player_Movement JammoMovementScript;
    public GameObject SwitchUI;
    public Portal p;

    private void Start()
    {
        switchCount = 0;
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if ( col.gameObject.tag == "Barrel")
        {
            //switchCount++; 
           door.transform.position += new Vector3(0f, 2.4f, 0f);
            JammoMovementScript.enabled = true;
            SwitchUI.SetActive(false);

            if (p.JammoInCage == true)
            {
                //Play Sound
                FindObjectOfType<MusicManager>().Play("ThankYou");

                p.JammoInCage = false;
            }
            
        }

        if (col.gameObject.tag == "Adam")
        {
            //switchCount++; 
            door.transform.position += new Vector3(0f, 2.4f, 0f);
            //Jammo.constraints = RigidbodyConstraints.FreezePosition;
            JammoMovementScript.enabled = true;
            SwitchUI.SetActive(false);

            if (p.JammoInCage == true)
            {
                //Play Sound
                FindObjectOfType<MusicManager>().Play("ThankYou");

                p.JammoInCage = false;
            }
        }


    }

    private void OnTriggerExit(Collider col)
    {
        if ( col.gameObject.tag == "Barrel")
        {
            //
            //switchCount--;
            door.transform.position -= new Vector3(0.011f, 2.4f, 1.02f);
        }

        if (col.gameObject.tag == "Adam")
        {
            //switchCount++; 
            door.transform.position -= new Vector3(0f, 2.4f, 0f);
            //Jammo.constraints = RigidbodyConstraints.None;
            
        }



    }
}
