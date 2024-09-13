using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;

    public float score = 0;

    public static ScoreManager instance;

    private void Awake()
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
