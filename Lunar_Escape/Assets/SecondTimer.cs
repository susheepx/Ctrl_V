using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class SecondTimer : MonoBehaviour
{
    public GameObject FinalTimer_GameObject;
    public bool isTimerFinalOpen = false;
    public bool isTimerFinal = false;
    private float timer = 0.0f;
    public TMP_Text textTimerFinal;
    // Update is called once per frame

    public GameObject timerTextFinal;
    public void ActivateTimerFinal()
    {
        if (isTimerFinal==false)
        {
            FinalTimer_GameObject.SetActive(true);
            timerTextFinal.SetActive(false);
            isTimerFinal = true;
        }
        else if (isTimerFinal==true)
        {
            FinalTimer_GameObject.SetActive(false);
        }
    }
    void Update()
    {
        if(isTimerFinal)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }        
    }

    public FadeScript fade;
    void DisplayTime()
    {
        if (timer<=74){
            int minutes = Mathf.FloorToInt(timer / 60.0f);
            int seconds = Mathf.FloorToInt(timer - minutes *60);
            textTimerFinal.text = string.Format("{0:00}:{1:00}", 1-minutes, 30-seconds) + " left...";
        }
        else if (timer == 0) {
            fade.fadeOutIn();
        }
    }    
}
