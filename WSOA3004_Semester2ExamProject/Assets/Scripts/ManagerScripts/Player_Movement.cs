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

    ///Jump///
    public KeyCode Jump;
    public Rigidbody rBody;
    public bool isGrounded2 = true;
    //private float yForce; //gravity 



    [SerializeField]
    protected string horizontalAxis;

    [SerializeField]
    protected string vericalAxis;

    [SerializeField]
    protected float angleOffset = 0f; // possible issue. 
    

    public Vector3 Position_Change;

    private float Easy_MaxX = 11;
    private float Easy_MaxZ = 11;
    private float Easy_MinX = -11;
    private float Easy_MinZ = -12;

    private float Normal_MaxX = 23;
    private float Normal_MaxZ = 17;
    private float Normal_MinX = -20;
    private float Normal_MinZ = -8;

    private float Hard_MaxX = 16;
    private float Hard_MaxZ = 10;
    private float Hard_MinX = -26;
    private float Hard_MinZ = -28;

    ///Animations///
    public Animator anim;

    //Ports//
    public bool Teleporting = false;
    public GameObject enteredPortal;

    ///Pick up Barrels//
    public KeyCode pickedUp;
    public Transform pickedUpDest;

    private float angle;


    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
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

        if (Input.GetKey(Jump) && isGrounded2 == true) //(Input.GetKey((KeyCode)Jump)   
        {
            rBody.AddForce(new Vector3(0, 13, 0), ForceMode.Impulse);
            isGrounded2 = false; // is false when jump button is pressed. 
            anim.SetBool("isJumping", true);

            //Play Sound
            FindObjectOfType<MusicManager>().Play("Jump");
        }

        var absXAxis = Mathf.Abs(input.x);
        var absYAxis = Mathf.Abs(input.y);

        if ( absXAxis > 0 || absYAxis > 0)
        {
            angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            var eulerRotation = transform.eulerAngles;
            eulerRotation.y = angle + angleOffset;      //possible issue.
            transform.eulerAngles = eulerRotation;
        }
        
        
        
        ClampPosition();

    }


    private void ClampPosition()
    {
        Position_Change = this.gameObject.transform.position;

        if (currentScene.name == "EasyScene 1" || currentScene.name == "EasyScene 2" || currentScene.name == "EasyScene 3")
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
        else if(currentScene.name == "NormalScene 1" || currentScene.name == "NormalScene 2" || currentScene.name == "NormalScene 3")
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
        else if(currentScene.name == "HardScene 1" || currentScene.name == "HardScene 2" || currentScene.name == "HardScene 3")
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

    /*  private void OnTriggerEnter(Collider other)
      {
          if (other.gameObject.tag == "ground") 
          {
              gc.isGrounded = true;

          }
      }

      private void OnTriggerExit(Collider other)
      {
          if (other.gameObject.tag != "ground")
          {
              gc.isGrounded = false;
              anim.SetBool("isJumping", false);

          }
      }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded2 = true;
            anim.SetBool("isJumping", false);

        }
    }


}
