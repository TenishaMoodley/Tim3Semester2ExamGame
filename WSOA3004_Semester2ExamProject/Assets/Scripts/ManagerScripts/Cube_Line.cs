using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Line : MonoBehaviour
{
    public GameObject Bean1_GO;
    public GameObject Bean2_GO;

    private Vector3 Bean1_Pos;
    private Vector3 Bean2_Pos;

    public GameObject Manager;

    private void Update()
    {
        Bean1_Pos = Bean1_GO.transform.position;
        Bean2_Pos = Bean2_GO.transform.position;

        UpdateCube();
    }

    private void UpdateCube()
    {
        float lineLength = Vector3.Distance(Bean1_Pos, Bean2_Pos);
        this.transform.localScale = new Vector3(.1f, 1f, lineLength);
        Vector3 midPoint = (Bean1_Pos + Bean2_Pos) / 2;
        this.transform.position = midPoint;

        this.transform.LookAt(Bean1_GO.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(collision.gameObject);
            Manager.GetComponent<Manager>().Addpoint();

            //Play Sound
            FindObjectOfType<MusicManager>().Play("Collected");
        }
    }
}
