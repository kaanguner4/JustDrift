using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{ 
    public GameObject gamePlayUI;
    public GameObject gameOverUI;
    public GameObject gamePauseUI;
    public ScoreManager scoreManager;
    public TextMeshProUGUI gameScoreText;

    public GameObject spawnedCar;
    public CarController carController;
    private float gameScore = 0;

    public static GameManager instance;

    void Awake()
    {
            instance = this;
    }

    public void Start()
    {
        Invoke("AfterStart", 0.2f);
        scoreManager = GetComponent<ScoreManager>();
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(true);
        gamePauseUI.SetActive(false);
    }

    public void AfterStart()
    {
        spawnedCar = CarSelectionScript.instance.spawnedCar;
        carController = spawnedCar.GetComponent<CarController>();
        Debug.Log("carcontroller = selectedcar.carcomtroller");
    }
    private void Update()
    {
        if (carController != null && carController.Fuel <= 0)
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
            gamePlayUI.SetActive(false);
            gameOverUI.SetActive(true);
            spawnedCar.SetActive(false);
            
            gameScoreText.text = "GAME SCORE: " +  ((int)GameScoreCalculator()).ToString();
            Debug.Log(ScoreManager.instance.score + "+" + carController.totalDistance);

            SaveScore();
    }
    public float GameScoreCalculator()
    {
        gameScore = (ScoreManager.instance.score*10) + (carController.totalDistance/10);

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

    public void SaveScore()
    {
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
