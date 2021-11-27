using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public int score;
    public TMP_Text Score_Txt_End;
    public TMP_Text Score_Txt_UI;
    public GameObject ArrowUI;
    public GameObject WASDUI;
    public GameObject LShiftUI;
    public GameObject RShiftUI;
    public GameObject BarrelUI;
    public int TotalCollectables;
    public destroyObject DestoryObjectScript;
    public GameObject EndPanel;

    private int Destroyed;

    private void Start()
    {
        EndPanel.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        Destroyed = 0;
    }


    public void Addpoint()
    {
        score++;
    }


    public void DestroyedAdd()
    {
        Destroyed++;
    }

    private void Update()
    {
        Debug.Log("Destroyed: " + Destroyed);

        StartCoroutine(Destroyself());


        Score_Txt_UI.text = "Score: " + score;
        Score_Txt_End.text = "Score: " + score;

        //The game controls UI disappearing after interacted with
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ArrowUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            WASDUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            LShiftUI.SetActive(false);
        }

        /*if (Input.GetKeyDown(KeyCode.RightShift))
        {
            RShiftUI.SetActive(false);
        }*/

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            BarrelUI.SetActive(false);
        }
    }

   

    IEnumerator Destroyself()
    {
        yield return new WaitForSeconds(DestoryObjectScript.CollectableTime);
        /*GameObject manager = GameObject.Find("Manager");
        manager.GetComponent<Manager>().DestroyedAdd();*/
        DestroyedAdd();

        if ((score + Destroyed) == TotalCollectables || score == TotalCollectables || Destroyed == TotalCollectables)
        {
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }

        Debug.Log("Coroutine works");
    }

}
