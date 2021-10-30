using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class destroyObject : MonoBehaviour
{
    public float CollectableSeconds;
    public Slider TimerSlider;
    public TMP_Text TimerText;
    public float CollectableTime;

    private bool stopTimer;

    void Start()
    {
        //StartCoroutine(Destroyself());
        stopTimer = false;
        TimerSlider.maxValue = CollectableTime;
        TimerSlider.value = CollectableTime;
    }

    private void Update()
    {
        float time = CollectableTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes*60);

        string TextTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = true;
            Destroy(gameObject);
            
        }
        if (stopTimer == false)
        {
            
            TimerText.text = TextTime;
            TimerSlider.value = time;
        }
    }

    IEnumerator Destroyself()
    {
        yield return new WaitForSeconds(CollectableSeconds);
        GameObject manager = GameObject.Find("Manager");
        manager.GetComponent<Manager>().DestroyedAdd();
        Destroy(gameObject);
    }
   
}
