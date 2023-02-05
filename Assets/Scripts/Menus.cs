using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject creditsScreen;
    public GameObject controlsScreen;

    private void Start()
    {
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void PlayGame()
    {
        TrackScore storage = gameObject.GetComponent<TrackScore>();
        TrackScore.totalHealth = 100;
        TrackScore.totalScore = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        controlsScreen.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }    
}
