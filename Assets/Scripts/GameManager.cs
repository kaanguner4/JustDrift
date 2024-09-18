using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject gamePlayUI;
    public GameObject gameOverUI;
    public GameObject car;
    public TextMeshProUGUI gameScoreText;

    public CarController carController;
    public ScoreManager scoreManager;
    private float gameScore = 0;

    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(true);
    }

    public void FixedUpdate()
    {
        
    }
    
    public void GameOver()
    {
        if (carController.Fuel <= 0)
        {
            gamePlayUI.SetActive(false);
            gameOverUI.SetActive(true);
            car.SetActive(false);
            
            gameScoreText.text = "SCORE: " +  ((int)GameScoreCalculator()).ToString();
        }
    }
    public float GameScoreCalculator()
    {
        gameScore = (ScoreManager.instance.score*10) + (CarController.instance.totalDistance);

        return gameScore;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }
}
