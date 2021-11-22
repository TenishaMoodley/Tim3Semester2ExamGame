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
   
    private void Start()
    {
        switchCount = 0;
    }


    // Start is called before the first frame update
    private void Update()
    {
       /* if (switchCount == 1)
        {
           

        }
        else 
        {
            //door.transform.position -= new Vector3(0f, 2.4f, 0f);

        }*/
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if ( col.gameObject.tag == "Barrel")
        {
            //switchCount++; 
           door.transform.position += new Vector3(0f, 2.4f, 0f);
        }

        if (col.gameObject.tag == "Adam")
        {
            //switchCount++; 
            door.transform.position += new Vector3(0f, 2.4f, 0f);
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
        }



    }
}
