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


    private string publicLeaderboardKey = "0eda27893df0fbe88ea1de7198b8e00aa9ba4094ee6d92a34825716c7e9e6467";


    private void Start()
    {
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
        LeaderboardCreator.ResetPlayer();
        Debug.Log("Set Leaderboard Entry");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu");
    }
}
