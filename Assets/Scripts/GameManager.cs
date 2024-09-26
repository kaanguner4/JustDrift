using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public GameObject gamePlayUI;
    public GameObject gameOverUI;
    public GameObject gamePauseUI;
    public GameObject car;
    public TextMeshProUGUI gameScoreText;

    public CarController carController;
    public ScoreManager scoreManager;
    private float gameScore = 0;

    

    public void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(true);
        gamePauseUI.SetActive(false);
    }
    private void Update()
    {
        if (carController.Fuel <= 0)
        {
            GameOver();
        }
    }

    public void Pause()
    {
        gamePlayUI.SetActive(false);
        gamePauseUI.SetActive(true);
    }


    public void GameOver()
    {
        if (carController.Fuel <= 0)
        {
            SaveScore();
            carController.Fuel = 0;
            gamePlayUI.SetActive(false);
            gameOverUI.SetActive(true);
            car.SetActive(false);
            
            gameScoreText.text = "GAME SCORE: " +  ((int)GameScoreCalculator()).ToString();
            Debug.Log(ScoreManager.instance.score + "+" + CarController.instance.totalDistance);
        }
    }
    public float GameScoreCalculator()
    {
        gameScore = (ScoreManager.instance.score*10) + (CarController.instance.totalDistance/10);

        return gameScore;
    }
    public void Ressume()
    {
        gamePauseUI.SetActive(false);
        gamePlayUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }

    public void SaveScore() {
        int scoreForSave =  (int)gameScore;
        PlayerPrefs.SetInt("GameScore", scoreForSave);
        PlayerPrefs.Save();
        Debug.Log("Score Saved");
    }

    public void GoLeaderboard()
    {

        SceneManager.LoadScene("LeaderboardScene");
        Debug.Log("Leaderboard");
    }
}
