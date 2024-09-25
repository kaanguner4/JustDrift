using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LeaderboardScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputScore;

    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    private int finalScore;

    private void Start()
    {
        GetScore();
    }
    public void GetScore()
    {
        finalScore = PlayerPrefs.GetInt("GameScore");
        inputScore.text = finalScore.ToString();
    }

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
