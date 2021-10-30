using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMidpoint : MonoBehaviour
{
    public GameObject Bean1_GO;
    public GameObject Bean2_GO;

    private Vector3 Bean1_Pos;
    private Vector3 Bean2_Pos;

    private void Update()
    {
        Bean1_Pos = Bean1_GO.transform.position;
        Bean2_Pos = Bean2_GO.transform.position;
        Vector3 midPoint = (Bean1_Pos + Bean2_Pos) / 2;
        this.transform.position = midPoint;

    }
}
