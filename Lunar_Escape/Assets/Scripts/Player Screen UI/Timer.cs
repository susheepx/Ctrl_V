 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject surveySubmitButton;
    public GameCanvasController controller;
    //Timer Display
    public TMP_Text textTimer;
    public GameObject Main, Leaderboard;

    public static float timer = 0.0f;
    private float timer1 = 0.0f;
    private float timer2 = 0.0f;
    private float timer3 = 0.0f;
    private int puzzlecount = 1;
    private bool isTimer = false;
    string s3 = "";
    string s4 = "";
    string s5 = "";
    string s6 = "";
    string s7 = "";
    string s8 = "";
    string s9 = "";
    string s10 = "";
    string s11 = "";
    string Buy="";
    public static int Hint1 = 0;
    public static int Hint2 = 0;
    public static int Hint3 = 0;
    public static float initialPuzzle2TimeNum = 0.0f;
    public static float initialPuzzle3TimeNum = 0.0f;
    public static float puzzletot = 0.0f;
    public static float adjpuzzle1time = 0.0f;
    public static float adjpuzzle2time = 0.0f;
    public static float adjpuzzle3time = 0.0f;

    public static int hintCount = 0;

    // Update is called once per frame
    void Update()
    {
        if(isTimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
        if (SceneManager.sceneCount == 3) {
            if((Rate.text.Length != 0 && Feelings.text.Length != 0 && Feedback.text.Length != 0) && Buy.Length != 0) {
                if (Buy == "yes") {
                    if (HowMuch.text.Length != 0) {
                        surveySubmitButtonOn();
                    }
                    else {
                        surveySubmitButtonOff();
                    }
                }
                else if (Buy == "no") 
                {
                    surveySubmitButtonOn();
                }
            }
            else {
                surveySubmitButtonOff();
            } 
        }

    }

    public void surveySubmitButtonOn() {
        surveySubmitButton.SetActive(true);
    }

    public void surveySubmitButtonOff() {
        surveySubmitButton.SetActive(false);
    }

    public void TurnOnLeaderboard()
    {
        Main.SetActive(false);
        Leaderboard.SetActive(true);
    }

    //Round down the timer to the lowest integer.
    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes *60);
        textTimer.text = string.Format("{0:00}:{1:00}", 29-minutes, 59-seconds) + " left...";
    }

    public void StartTimer()
    {
        isTimer = true;
    }

    public void StopTimer()
    {
        puzzlecount += 1;
        if(puzzlecount == 2)
        {
            timer1 = timer;
            adjpuzzle1time = timer;
            initialPuzzle2TimeNum = timer;
            
        }

        if (puzzlecount == 3)
        {
            timer2 = timer - timer1;
            initialPuzzle3TimeNum = timer;
            adjpuzzle2time=timer-adjpuzzle1time;
            
            
        }
        if (puzzlecount == 4)
        {
            timer3 = timer-timer1-timer2;

            adjpuzzle3time = timer-adjpuzzle2time-adjpuzzle1time;
            puzzletot = timer1+timer2+timer3;
        }
        isTimer = false;
            
    }
    
    public void GiveHint()
    {
        if (puzzlecount == 1 && hintCount < 4)
        {
            Hint1 += 1;
            timer+= 90.0f;
            controller.openDialogueBox(hintCount, controller.Hints);
            hintCount+=1;
        }
        else if (puzzlecount == 2 && hintCount < 8)
        {
            Hint2 += 1;
            timer+= 120.0f;
            controller.openDialogueBox(hintCount, controller.Hints);
            hintCount+=1;
        }
        
        else if(puzzlecount == 3 && hintCount < 12)
        {
            Hint3 += 1;
            timer+=150.0f;
            controller.openDialogueBox(hintCount, controller.Hints);
            hintCount+=1;
        }
        else { 
            controller.openDialogueBox(12, controller.Hints);
        }
        

    }

    
    public static string Username = "";
	[SerializeField] TMP_InputField Rate;
	[SerializeField] TMP_InputField Feelings;
	[SerializeField] TMP_InputField Feedback;
    [SerializeField] Toggle yesBuytoggle;
    [SerializeField] Toggle noBuytoggle;

    //Toggle fields unneede. Gameobjects are for ".SetActive" cmds.  Attach the toggles to the corresponding game objects.
    [SerializeField] GameObject NoBuygameobj;
    [SerializeField] GameObject YesBuygameobj;

    //Also attach the gameobject of "HowMuchgameobj" to the "HowMuch" input field. That disables the Input Field in the code.
    //Did this because could not figure out how to use ".SetActive" to Input Fields and Toggles.
    [SerializeField] GameObject HowMuchgameobj;
    [SerializeField] TMP_InputField HowMuch;
    [SerializeField] GameObject TimerText;
    [SerializeField] GameObject HintPopup;

    bool isHintPopupOpen = false;
    public void HintPopupAppear(){
        if(isHintPopupOpen==false)
            {
                isHintPopupOpen=true;
                HintPopup.SetActive(true);
            }
        else if(isHintPopupOpen==true)
            {
                isHintPopupOpen=false;
                HintPopup.SetActive(false);
            }
    }


    public GameObject menuPopup;
    bool isMenuPopupOpen = false;
    public void MenuPopupAppear(){
        if(isMenuPopupOpen==false)
            {
                isMenuPopupOpen=true;
                menuPopup.SetActive(true);
            }
        else if(isMenuPopupOpen==true)
            {
                isMenuPopupOpen=false;
                menuPopup.SetActive(false);
            }
    }

    bool isClockOpen = false;
    public void OpenClock()
    {
        if(isClockOpen==false){
            isClockOpen=true;
            TimerText.SetActive(true);
        }
        else if (isClockOpen==true){
            isClockOpen=false;
            TimerText.SetActive(false);
        }
    }
    bool SelectYes = false;
    bool SelectNo = false;

    public void OnSelect()
    {
        if (SelectYes==false){
            Buy = "yes";
            NoBuygameobj.SetActive(false);
            HowMuchgameobj.SetActive(true);
            SelectYes= true;

        }
        else
        {
            Buy = "";
            NoBuygameobj.SetActive(true);
            HowMuchgameobj.SetActive(false);
            SelectYes = false;
            HowMuch.text = "";
        }
        
    }

    public void OnSelectNo()
    {
        if (SelectNo==false)
        {
            Buy = "no";
            YesBuygameobj.SetActive(false);
            NoBuygameobj.SetActive(true);
            SelectNo=true;
        }
        else if (SelectNo==true)
        {
            Buy="";
            YesBuygameobj.SetActive(true);
            SelectNo=false;
        }
    }


    private string URL = "https://docs.google.com/forms/d/1a6D7c8cXegifbgLlZqPP-7LXNG3HCfVt1Xe26Xk5dzA/formResponse";
    public void Send()
    {   
        int puzzletot = Mathf.FloorToInt(timer);
        int initialPuzzle2TimeNumint = Mathf.FloorToInt(initialPuzzle2TimeNum);
        int initialPuzzle3TimeNumint = Mathf.FloorToInt(initialPuzzle3TimeNum);
        int adjpuzzle1timeint = Mathf.FloorToInt(adjpuzzle1time);
        int adjpuzzle2timeint = Mathf.FloorToInt(adjpuzzle2time);
        int adjpuzzle3timeint = Mathf.FloorToInt(adjpuzzle3time);
        s3 = Hint1.ToString();
        s4 = adjpuzzle1timeint.ToString();
        s5 = initialPuzzle2TimeNumint.ToString();
        s6 = Hint2.ToString();
        s7 = adjpuzzle2timeint.ToString();
        s8 = initialPuzzle3TimeNumint.ToString();
        s9 = Hint3.ToString();
        s10 = adjpuzzle3timeint.ToString();
        s11 = puzzletot.ToString();
        
        StartCoroutine(Post(Username, s3, s4, s5, s6, s7, s8, s9, s10, s11, Rate.text, Feelings.text, Feedback.text, Buy, HowMuch.text));

    
    }
    
    IEnumerator Post(string s1, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string Rate, string Market, string Feedback, string Buy, string HowMuch)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.12312327", s1);
	    form.AddField("entry.624842187", s3);
	    form.AddField("entry.2046847554", s4);
	    form.AddField("entry.617106974", s5);
	    form.AddField("entry.795759392", s6);
	    form.AddField("entry.2136019495", s7);
	    form.AddField("entry.717329050", s8);
	    form.AddField("entry.448493495", s9);
	    form.AddField("entry.1272641663", s10);
	    form.AddField("entry.1053050007", s11);
	    form.AddField("entry.313190303", Rate);
	    form.AddField("entry.1289036563", Market);
	    form.AddField("entry.512938227", Feedback);
        form.AddField("entry.1123361939", Buy);
        form.AddField("entry.321758945", HowMuch);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

        yield return new WaitForSeconds(.5f);

        UsernameWindow.isSurveySubmitted = true;

        SceneManager.LoadScene(sceneBuildIndex:0);


    }

}
