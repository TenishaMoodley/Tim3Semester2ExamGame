using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpScript : MonoBehaviour
{
    public float TweenTime;
    public float Strength;

    void Start()
    {
        TweenStartUpAnimation();
        StartCoroutine(Proceed());
    }

    public void TweenStartUpAnimation()
    {
        LeanTween.cancel(gameObject);

        transform.localScale = Vector3.one;

        LeanTween.scale(gameObject, Vector3.one * Strength, TweenTime).setEaseInOutBounce();
    }

    public IEnumerator Proceed()
    {
        yield return new WaitForSeconds(8f);

        SceneManager.LoadScene(1);
    }
}
