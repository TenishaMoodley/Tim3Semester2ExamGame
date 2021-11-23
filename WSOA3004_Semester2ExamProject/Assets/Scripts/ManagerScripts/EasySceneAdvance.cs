using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class EasySceneAdvance
{
    [SerializeField]
    protected List<int> scenarios;

    private static EasySceneAdvance instance;

    private EasySceneAdvance()
    {
        scenarios = new List<int> { 5, 6, 7 };
    }

    public static EasySceneAdvance Instance
    {
        get => instance == null ? (instance = new EasySceneAdvance()) : instance;
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
