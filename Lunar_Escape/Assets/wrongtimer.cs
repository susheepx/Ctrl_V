using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.EventSystems;

public class wrongtimer : MonoBehaviour
{
    //Timer Display
    public TMP_Text textTimer;
    public GameObject Main, Leaderboard;

    private float timer = 0.0f;
    private float timer1 = 0.0f;
    private float timer2 = 0.0f;
    private float timer3 = 0.0f;
    private int puzzlecount = 0;
    private bool isTimer = false;
    string s;
    string s3;
    string s4;
    string s5;
    string s6;
    string s7;
    string s8;
    string s9;
    string s10;
    string s11;
    string Buy;
    private int Hint1 = 0;
    private int Hint2 = 0;
    private int Hint3 = 0;
    private float initialPuzzle2TimeNum = 0.0f;
    private float initialPuzzle3TimeNum = 0.0f;
    private float puzzletot = 0.0f;
    private float adjpuzzle1time = 0.0f;
    private float adjpuzzle2time = 0.0f;
    private float adjpuzzle3time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(isTimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
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
        textTimer.text = string.Format("{0:00}:{1:00}", 29-minutes, 59-seconds);
    }

    public void StartTimer()
    {
        isTimer = true;
    }

    public void StopTimer()
    {
        puzzlecount += 1;
        if(puzzlecount == 1)
        {
            timer1 = timer;
            adjpuzzle1time = timer;
            initialPuzzle2TimeNum = timer;
            
        }

        if (puzzlecount == 2)
        {
            timer2 = timer - timer1;
            initialPuzzle3TimeNum = timer;
            adjpuzzle2time=timer-adjpuzzle1time;
            
            
        }
        if (puzzlecount == 3)
        {
            timer3 = timer-timer1-timer2;

            adjpuzzle3time = timer-adjpuzzle2time-adjpuzzle1time;
            puzzletot = timer1+timer2+timer3;
        }
        isTimer = false;
            
    }
    public void GiveHint1()
    {
        Hint1 += 1;
        timer+= 90.0f;
    }

    public void GiveHint2()
    {
        Hint2 += 1;
        timer+= 120.0f;
    }

    public void GiveHint3()
    {
        Hint3 += 1;
        timer+=150.0f;
    }
    
    [SerializeField] InputField Username;
	[SerializeField] InputField Rate;
	[SerializeField] InputField Market;
	[SerializeField] InputField Feedback;
    [SerializeField] Toggle yesBuytoggle;
    [SerializeField] Toggle noBuytoggle;
    [SerializeField] GameObject NoBuygameobj;

    [SerializeField] GameObject YesBuygameobj;
    [SerializeField] GameObject HowMuchgameobj;
    
    [SerializeField] InputField HowMuch;
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
            SelectNo=true;
        }
        else
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
        
        StartCoroutine(Post(Username.text, s3, s4, s5, s6, s7, s8, s9, s10, s11, Rate.text, Market.text, Feedback.text, Buy, HowMuch.text));
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

    }

}
