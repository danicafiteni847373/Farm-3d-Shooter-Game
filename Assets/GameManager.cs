using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int gameDifficulty = 0;

    [SerializeField] private int score;
    public Health health;
    public ScoreManager scoree;

    //Singleton Approach 
    protected static GameManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
        DontDestroyOnLoad(this);
        score = 1000;
    }

    public void StartGame(int difficulty)
    {
        gameDifficulty = difficulty;
        SceneManager.sceneLoaded += SceneChanged;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
    }

    private void SceneChanged(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            string difficulty;
            switch (gameDifficulty)
            {
                case 3:
                    difficulty = "Hard";
                    if (gameDifficulty == 3)
                    {
                        //health.ReduceHealthLvl2();
                        Debug.Log("Level 3");
                    }
                    break;
                case 2:
                    difficulty = "Medium";
                    Debug.Log("Level 2");
                    break;
                default:
                    difficulty = "Easy";
                    Debug.Log("Level 1");
                    break;
            }
            //GameObject.Find("Difficulty").GetComponent<TMP_Text>().text = "Difficulty: " + difficulty;
            //GameObject.Find("Score").GetComponent<TMP_Text>().text = "Score: " + score;

        }
        else if (scene.name == "ScoreScene")
        {
            GameObject.Find("Highscore").GetComponent<TMP_Text>().text = "Score: " + score;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneChanged;
    }
}