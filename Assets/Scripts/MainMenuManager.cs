using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    private void Awake()
    {
        Debug.Log("Game Opened");
        mainMenuUI.SetActive(true);
    }
    public void TapToStart()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Started");
        mainMenuUI.SetActive(false);

    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
        Debug.Log("Leaderboard");
        mainMenuUI.SetActive(false);
    }

}
