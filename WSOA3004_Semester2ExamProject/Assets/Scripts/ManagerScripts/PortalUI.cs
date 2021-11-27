using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUI : MonoBehaviour
{
    public GameObject PortalUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PortalUi.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Adam") //|| collision.gameObject.tag == "Connection"
        {
            PortalUi.SetActive(true);

        }

    }
}
