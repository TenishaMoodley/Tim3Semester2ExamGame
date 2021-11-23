using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTest : MonoBehaviour
{
    public KeyCode Jump;
    public Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rBody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse); 
        
    }
}
