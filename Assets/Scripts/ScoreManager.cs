using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;

    public float score = 0;
    public float gameScore = 0; 

    public static ScoreManager instance;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "SCORE:" + score.ToString();
    }

    public void AddScore(float value)
    {
        score += value;
        scoreText.text = "SCORE:" + score.ToString();
    }
}
