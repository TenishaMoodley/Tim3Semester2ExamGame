using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class HardSceneAdvance
{
    [SerializeField]
    protected List<int> scenarios;

    private static HardSceneAdvance instance;

    private HardSceneAdvance()
    {
        scenarios = new List<int> { 11 , 12, 13};
    }

    public static HardSceneAdvance Instance
    {
        get => instance == null ? (instance = new HardSceneAdvance()) : instance;
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
