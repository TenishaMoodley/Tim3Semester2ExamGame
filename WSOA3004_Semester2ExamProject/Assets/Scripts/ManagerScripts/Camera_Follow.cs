using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [Header("Rotation (Left mouse drag)")]
    public float speed = 1f;
    private float X;
    private float Y;
    [Header("FOV (Mouse wheel to zoom)")]
    public float minFOV = 30f;
    public float maxFOV = 100f;
    public float sensitivity = 10f;
    public float FOV;
    [Header("Pan (Right mouse drag)")]
    public float panSpeed = 10f;

    [Header("Left Alt to Reset Camera")]
    public KeyCode Reset_Camera = KeyCode.LeftAlt;
    void Update()
    {
        //rotate camera around centre of transform
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }

        //change (Field of View) 
        FOV = Camera.main.fieldOfView;
        FOV += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;

        //move camera around scene xyz
        if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * panSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * panSpeed * Time.deltaTime;

            transform.Translate(-newPosition);
            
        }

        //reset position FOV and rotation
        if (Input.GetKeyDown(Reset_Camera))
        {
            this.transform.position = new Vector3 (0,10,-10);
            transform.rotation = Quaternion.Euler(30, 0, 0);
            Camera.main.fieldOfView = 80;
        }

    }
    
}
