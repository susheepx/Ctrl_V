using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI time;
    // Start is called before the first frame update
    void Start()
    {
        username.text = UsernameWindow.username;
        time.text = Timer.puzzletot.ToString();
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
