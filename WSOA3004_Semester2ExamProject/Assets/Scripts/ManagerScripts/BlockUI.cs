using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUI : MonoBehaviour
{
    public GameObject theBlockUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jammo")
        {
            theBlockUI.SetActive(true);
        }
        
    }
}
