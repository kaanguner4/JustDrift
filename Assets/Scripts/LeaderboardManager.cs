using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    LeaderboardScoreManager scoreManager;

    private string publicLeaderboardKey = "d3ea1bccf04eee49ae3f621f24634c2bb7502a7365b0ebd8729c6b230c4c694e";


    private void Start()
    {
        scoreManager = GetComponent<LeaderboardScoreManager>();
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
        Debug.Log("Get Leaderboard");
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
            GetLeaderboard();
        }));
        ResetPlayer();
        Debug.Log("Set Leaderboard Entry");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }

    public void ResetPlayer()
    {
        LeaderboardCreator.ResetPlayer();
        Debug.Log("PlayerReset");
    }
}
