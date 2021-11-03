using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player_Movement : MonoBehaviour
{
    public KeyCode Forward;
    public KeyCode Backward;
    public KeyCode Move_Left;
    public KeyCode Move_right;

    public float speed;

    /// Additions///
    public KeyCode Jump;
    public float jumpForce;
    public Rigidbody rBody;

    ///Jump///
    public bool isGrounded = true;
    public bool isOnBox = false; 

    [SerializeField]
    protected string horizontalAxis;

    [SerializeField]
    protected string vericalAxis;

    [SerializeField]
    protected float angleOffset = 90; // possible issue. 
    

    public Vector3 Position_Change;

    private float MaxX = 23;
    private float MaxZ = 17;
    private float MinX = -20;
    private float MinZ = -8;

    ///Animations///
    public Animator anim;

    //Ports//
    public bool Teleporting = false;
    public GameObject enteredPortal;

    ///Pick up Barrels//
    public KeyCode pickedUp;
    public Transform pickedUpDest;




    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        //Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       // Vector3 forward = faceForward.position - transform.position;
       
       // Vector3 left = faceLeft.position - transform.position;
       //Vector3 rigth = faceRight.position - transform.position    
    }



    private void FixedUpdate()
    {
        var x = Input.GetAxis(horizontalAxis);
        var y = Input.GetAxis(vericalAxis);
        
        Vector2 input = new Vector2(x, y);
        //Debug.Log(input);

        if (Input.GetKey(Forward))
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime, Space.World);
            anim.SetBool("isRunningF", true);

           // blank.y = 1;
        }
        if (!Input.GetKey(Forward)) 
        {
            anim.SetBool("isRunningF", false); 
        }


        if (Input.GetKey(Backward))
        {
            transform.Translate(-Vector3.forward * speed * Time.fixedDeltaTime, Space.World);
            anim.SetBool("isRunningB", true);
           // blank.y = -1; 
        }
        if (!Input.GetKey(Backward))
        {
            anim.SetBool("isRunningB", false);
        }


        if (Input.GetKey(Move_right))
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime, Space.World);
            anim.SetBool("isRunningR", true);
           // blank.x = 1;
        }
        if (!Input.GetKey(Move_right))
        {
            anim.SetBool("isRunningR", false);
        }


        if (Input.GetKey(Move_Left))
        {
           transform.Translate(Vector3.left * speed * Time.fixedDeltaTime, Space.World);
            anim.SetBool("isRunningL", true);
           // blank.x = -1;
        }
        if (!Input.GetKey(Move_Left))
        {
            anim.SetBool("isRunningL", false);
        }

        HandleJump();
        

        var angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        var eulerRotation = transform.eulerAngles;
        eulerRotation.y = angle + angleOffset;      //possible issue.
        transform.eulerAngles = eulerRotation;
        
        
        ClampPosition();

    }

  

    private void HandleJump()
    {
        if (Input.GetKey((KeyCode)Jump) && isGrounded)
        {
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isOnBox = true;
        }

      
    }

    private void boxJump() 
    {
       /* if (Input.GetKey((KeyCode)Jump) && isOnBox)
        {
            rBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnBox = true;
        }*/

    }

    private void ClampPosition()
    {
        Position_Change = transform.position;
        if (Position_Change.x >= MaxX)
        {
            Position_Change.x = MaxX;
            transform.position = Position_Change;
        }

        if (Position_Change.x <= MinX)
        {
            Position_Change.x = MinX;
            transform.position = Position_Change;
        }

        if (Position_Change.z >= MaxZ)
        {
            Position_Change.z = MaxZ;
            transform.position = Position_Change;
        }

        if (Position_Change.z <= MinZ)
        {
            Position_Change.z = MinZ;
            transform.position = Position_Change;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            //isOnBox = false;
        }

        if (collision.gameObject.CompareTag("box"))
        {
            isOnBox = true;
            //isGrounded = false;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; ;
           // isOnBox = false;

        }

        if (collision.gameObject.CompareTag("box")) 
        {
            //isOnBox = false;
           // isGrounded = true;
        
        }


    }
}
