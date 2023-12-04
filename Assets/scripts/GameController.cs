using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private int enemiesKilled = 0;
    public int winCondition = 5;
    public string endGameSceneName = "EndGameScene";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= winCondition)
        {
            // You win!
            Debug.Log("You win!");

            // Load the EndGameScene
            LoadEndGameScene();
        }
    }

    void LoadEndGameScene()
    {
        // Check if the EndGameScene exists in the build settings
        if (SceneManager.GetSceneByName(endGameSceneName) != null)
        {
            // Load the EndGameScene
            SceneManager.LoadScene(endGameSceneName);
        }
        else
        {
            Debug.LogError("EndGameScene not found in the build settings!");
        }
    }
}
