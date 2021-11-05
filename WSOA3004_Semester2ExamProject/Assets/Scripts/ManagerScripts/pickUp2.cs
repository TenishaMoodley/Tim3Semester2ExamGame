using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp2 : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float speed; 

    
    public Transform destination;
    public GameObject BarrelUI;
    public Animator anim;
    private Rigidbody rBody; 

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
           // transform.position = Vector3.MoveTowards(transform.position, followObject.transform.position, speed * Time.deltaTime); //barrel position moves towards destination at a specific speed.
            //rBody.velocity = new Vector3(20f, 0f, 0f);
            anim.SetBool("isCarrying", false);
        }
    }

    void Update()
    {
        rBody = GetComponent<Rigidbody>(); 
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            BarrelUI.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.tag == "Jammo" ) 
        {
            Player_Movement link = collide.gameObject.GetComponent<Player_Movement>();
            Debug.Log("contact");
            //Input.GetKey(KeyCode.E)

            BarrelUI.SetActive(true);
            //GetComponent<Rigidbody>().useGravity = false;
            //GetComponent<Rigidbody>().mass = 0f;
            this.transform.position = destination.position;
            this.transform.parent = GameObject.Find("pickedUp").transform;
            anim.SetBool("isCarrying", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
