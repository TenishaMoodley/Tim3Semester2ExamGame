using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    Scene currentScene;
    public KeyCode Forward;
    public KeyCode Backward;
    public KeyCode Move_Left;
    public KeyCode Move_right;


    public float speed;

    /// Additions///
    public KeyCode Jump;
    public float jumpForce;
    public Rigidbody rBody;
    //private float yForce; //gravity 

    ///Jump///
    public bool isGrounded = true;
   

    [SerializeField]
    protected string horizontalAxis;

    [SerializeField]
    protected string vericalAxis;

    [SerializeField]
    protected float angleOffset = 0f; // possible issue. 
    

    public Vector3 Position_Change;

    private float Easy_MaxX = 23;
    private float Easy_MaxZ = 17;
    private float Easy_MinX = -20;
    private float Easy_MinZ = -8;

    private float Normal_MaxX = 23;
    private float Normal_MaxZ = 17;
    private float Normal_MinX = -20;
    private float Normal_MinZ = -8;

    private float Hard_MaxX = 19;
    private float Hard_MaxZ = 54;
    private float Hard_MinX = -29;
    private float Hard_MinZ = -29;

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
        currentScene = SceneManager.GetActiveScene();
        rBody = GetComponent<Rigidbody>();
        //Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Vector3 forward = faceForward.position - transform.position;

        // Vector3 left = faceLeft.position - transform.position;
        //Vector3 rigth = faceRight.position - transform.position
        //yForce += Physics.gravity.y * Time.deltaTime; 
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
           // yForce = jumpForce;
        }

      
    }

    

    private void ClampPosition()
    {
        Position_Change = this.gameObject.transform.position;

        if (currentScene.name == "EasyScene")
        {
            if (Position_Change.x >= Easy_MaxX)
            {
                Position_Change.x = Easy_MaxX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.x <= Easy_MinX)
            {
                Position_Change.x = Easy_MinX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z >= Easy_MaxZ)
            {
                Position_Change.z = Easy_MaxZ;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z <= Easy_MinZ)
            {
                Position_Change.z = Easy_MinZ;
                this.transform.position = Position_Change;
            }
        }
        else if(currentScene.name == "NormalScene")
        {
            if (Position_Change.x >= Normal_MaxX)
            {
                Position_Change.x = Normal_MaxX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.x <= Normal_MinX)
            {
                Position_Change.x = Normal_MinX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z >= Normal_MaxZ)
            {
                Position_Change.z = Normal_MaxZ;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z <= Normal_MinZ)
            {
                Position_Change.z = Normal_MinZ;
                this.transform.position = Position_Change;
            }

        }
        else if(currentScene.name == "HardScene")
        {
            if (Position_Change.x >= Hard_MaxX)
            {
                Position_Change.x = Hard_MaxX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.x <= Hard_MinX)
            {
                Position_Change.x = Hard_MinX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z >= Hard_MaxZ)
            {
                Position_Change.z = Hard_MaxZ;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z <= Hard_MinZ)
            {
                Position_Change.z = Hard_MinZ;
                this.transform.position = Position_Change;
            }
        }

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            //isOnBox = false;
        }

      

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; ;
          

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="ground") 
        {
            isGrounded = true;
        
        }
    }
}
