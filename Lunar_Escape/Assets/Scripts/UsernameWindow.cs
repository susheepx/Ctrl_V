using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UsernameWindow : MonoBehaviour
{
    public TMP_InputField inputUsername;
    public string username;
    private void Awake() {;
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "ExitUsername")
            gameObject.SetActive(false);
        else if (username.Length > 1)
            SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void UsernameInputted(string s)
    {
        username = inputUsername.GetComponent<TMP_InputField>().text;
        Debug.Log(username);
    }

    

    
}
