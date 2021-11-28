using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTest : MonoBehaviour
{
    public KeyCode Jump;
    public Rigidbody rBody;
    public bool isGrounded2 = true;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(Jump)&& isGrounded2 == true) //(Input.GetKey((KeyCode)Jump)   
        {
            rBody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            isGrounded2 = false; // is false when jump button is pressed. 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" ) 
        {
            isGrounded2 = true;
        
        }
    }
}
