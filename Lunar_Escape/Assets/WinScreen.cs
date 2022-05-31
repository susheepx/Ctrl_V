using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI time;
    float timer =0.0f;
    // Start is called before the first frame update
    void Start()
    {
        username.text = UsernameWindow.username;
        timer = Timer.puzzletot;
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes *60);
        time.text = string.Format("{0:00}:{1:00}", 29-minutes, 59-seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject surveyCanvas;
    public GameObject submitSurvey;
    public void startSurvey() {
        submitSurvey.SetActive(false);
        surveyCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
