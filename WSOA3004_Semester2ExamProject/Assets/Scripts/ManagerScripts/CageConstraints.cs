using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageConstraints : MonoBehaviour
{
    private float Cage_MaxX = 0.67f;
    private float Cage_MinX = -0.67f;

    private float Cage_MaxZ = 0.48f;
    private float Cage_MinZ = -0.43f;

    public Vector3 Position_Change;
    public GameObject Jammo;

    private void FixedUpdate()
    {
        ClampPositionInCage();
    }

    private void ClampPositionInCage()
    {
        Position_Change = this.gameObject.transform.position;

            if (Position_Change.x >= Cage_MaxX)
            {
                Position_Change.x = Cage_MaxX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.x <= Cage_MinX)
            {
                Position_Change.x = Cage_MinX;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z >= Cage_MaxZ)
            {
                Position_Change.z = Cage_MaxZ;
                this.transform.position = Position_Change;
            }

            if (Position_Change.z <= Cage_MinZ)
            {
                Position_Change.z = Cage_MinZ;
                this.transform.position = Position_Change;
            }
    }
}
