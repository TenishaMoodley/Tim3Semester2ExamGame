using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class NormalSceneAdvance
{
    [SerializeField]
    protected List<int> scenarios;

    private static NormalSceneAdvance instance;

    private NormalSceneAdvance()
    {
        scenarios = new List<int> { 8, 9, 10 };
    }

    public static NormalSceneAdvance Instance
    {
        get => instance == null ? (instance = new NormalSceneAdvance()) : instance;
    }

    public void LoadNextScene()
    {
        if (scenarios.Count == 0)
            return;
        int randomIndex = UnityEngine.Random.Range(0, scenarios.Count);
        int currentScenario = scenarios[randomIndex];
        //scenarios.RemoveAt(randomIndex);
        SceneManager.LoadScene(currentScenario);
    }

}
