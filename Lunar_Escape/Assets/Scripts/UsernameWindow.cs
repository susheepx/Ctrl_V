using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UsernameWindow : MonoBehaviour
{
    public DisplayLeaderboard displayLeaderboard;
    public static bool isSurveySubmitted = false;
    public GameObject leaderboardCanvas, mainScreenCanvas;
    public TMP_InputField inputUsername;
    public static string username = "erika";
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
        Timer.Username = inputUsername.GetComponent<TMP_InputField>().text;
    }

    public void PlayGame()
    {
        if (Timer.Username.Length > 1) {
            SceneManager.LoadScene(sceneBuildIndex:1);
        }
    }
    

    
}
