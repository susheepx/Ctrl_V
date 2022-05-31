using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UsernameWindow : MonoBehaviour
{
    public AudioSource TitleMusic;
    public DisplayLeaderboard displayLeaderboard;
    public static bool isSurveySubmitted = false;
    public GameObject leaderboardCanvas, mainScreenCanvas;
    public TMP_InputField inputUsername;
    public static string username = "LRatio";
    private void Awake() {;
        leaderboardCanvas.SetActive(false);
        gameObject.SetActive(false);
        if(isSurveySubmitted == true) {
            leaderboardCanvas.SetActive(true);
            mainScreenCanvas.SetActive(false);
            displayLeaderboard.Start();
        }
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "ExitUsername") {
            gameObject.SetActive(false);
        }
    }

    public void UsernameInputted(string s)
    {
        username = inputUsername.GetComponent<TMP_InputField>().text;
        Timer.Username = inputUsername.GetComponent<TMP_InputField>().text;
    }

    public void PlayGame()
    {
        if (Timer.Username.Length > 1) {
            //TitleMusic.Stop();
            SceneManager.LoadScene(sceneBuildIndex:4);
        }
    }
    

    
}
