using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeaderboardScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputScore;

    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;
    private void Start()
    {
        GetScore();
    }
    public void GetScore()
    {
        int finalScore = PlayerPrefs.GetInt("CurrentScore");
        inputScore.text = finalScore.ToString();
    }


    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
