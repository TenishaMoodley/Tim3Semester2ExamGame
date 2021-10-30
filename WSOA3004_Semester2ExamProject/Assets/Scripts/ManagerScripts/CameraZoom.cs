using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float Player_Distance;
    public float MaxFOV;
    public float MinFOV;
    public float Curr_FOV;

    public float value;

    public GameObject Bean1_GO;
    public GameObject Bean2_GO;
    public Vector3 Cameraoffset;

    private void Update()
    {
        Player_Distance = Vector3.Distance(Bean1_GO.transform.position, Bean2_GO.transform.position);
        Curr_FOV = 30 + (Player_Distance - value);
        Curr_FOV =  Mathf.Clamp(Curr_FOV, MinFOV, MaxFOV);
        Camera.main.fieldOfView = Curr_FOV;

        FollowMid();
    }

    public void FollowMid()
    {
        Vector3 MidPoint = (Bean1_GO.transform.position + Bean2_GO.transform.position) / 2;
        this.gameObject.transform.position = MidPoint + Cameraoffset;
    }

}
