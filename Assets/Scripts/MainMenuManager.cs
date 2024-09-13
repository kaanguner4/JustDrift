using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    private void Awake()
    {
        Debug.Log("GameOpened");
        mainMenuUI.SetActive(true);
    }
    public void TapToStart()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Started");
        mainMenuUI.SetActive(false);

    }

}
