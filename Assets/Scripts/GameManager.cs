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
    public TextMeshProUGUI scoreText;

    public CarController carController;
    public ScoreManager scoreManager;
    private float score = 0;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(true);
    }

    public void FixedUpdate()
    {
        
    }
    private void printScore()
    {
        if (carController.Fuel <= 0)
        {
            score = scoreManager.score;
            scoreText.text = "SCORE:" + score.ToString();
        }
    }
    public void GameOver()
    {
        if (carController.Fuel <= 0)
        {
            

            gamePlayUI.SetActive(false);
            gameOverUI.SetActive(true);
            car.SetActive(false);

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");
    }
}
