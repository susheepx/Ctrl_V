
using System;
using System.IO;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEditor;
using TMPro;

public class DisplayLeaderboard : MonoBehaviour
{
    public TMP_Text UserFirstPlace, UserSecondPlace, UserThirdPlace, UserFourthPlace, UserFifthPlace, TimeFirstPlace, TimeSecondPlace, TimeThirdPlace, TimeFourthPlace, TimeFifthPlace;
    public Canvas Canvas1, Leaderboard;

    static readonly string[] Scopes = {Google.Apis.Sheets.v4.SheetsService.Scope.Spreadsheets};
    static readonly string ApplicationName ="FunSheets";
    static readonly string SpreadsheetId ="1PkpWaIcYMY7c7Y0RjCimRiLvofZS7HmtOKHQayv0do0";
    static readonly string sheet = "FormResponse1";

    static Google.Apis.Sheets.v4.SheetsService service;

    static public List<string> Usernames = new List<string>();
    static public List<string> Times = new List<string>();

    string Username1;
    string Time1;
    string Username2;
    string Time2;
    string Username3;
    string Time3;
    string Username4;
    string Time4;
    string Username5;
    string Time5;
    public void Start()
    {
        
        Google.Apis.Auth.OAuth2.GoogleCredential credential;

        using var stream = new FileStream("total-thinker-350701-4aef5686df55.json", FileMode.Open, FileAccess.Read);
        {
                credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
        }
        service = new Google.Apis.Sheets.v4.SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
        //Note from Justin Sip (myself): Please change, if possible.  Working but inefficient.
        ReadEntries1();
        ReadEntries2();
        ReadEntries3();
        ReadEntries4();
        ReadEntries5();
        UserFirstPlace.text= Username1;
        UserSecondPlace.text = Username2;
        UserThirdPlace.text = Username3;
        UserFourthPlace.text = Username4;
        UserFifthPlace.text = Username5;
        TimeFirstPlace.text = Time1;
        TimeSecondPlace.text = Time2;
        TimeThirdPlace.text = Time3;
        TimeFourthPlace.text = Time4;
        TimeFifthPlace.text = Time5;

    }

        public void ReadEntries1() { //rangelow and rangehigh are cells like A1 or F12
            var range = $"{sheet}!A2:P2"; 
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach(var row in values)
                {
                    Username1=($"{row[0]}");
                    Time1=($"{row[15]}");
                }
                
            }
        }

        public void ReadEntries2() { //rangelow and rangehigh are cells like A1 or F12
            var range = $"{sheet}!A3:P3"; 
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach(var row in values)
                {
                    Username2=($"{row[0]}");
                    Time2=($"{row[15]}");
                }
                
            }
        }

        public void ReadEntries3() { //rangelow and rangehigh are cells like A1 or F12
            var range = $"{sheet}!A4:P4"; 
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach(var row in values)
                {
                    Username3=($"{row[0]}");
                    Time3=($"{row[15]}");
                }
                
            }
        }
        public void ReadEntries4() { //rangelow and rangehigh are cells like A1 or F12
            var range = $"{sheet}!A5:P5"; 
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach(var row in values)
                {
                    Username4=($"{row[0]}");
                    Time4=($"{row[15]}");
                }
                
            }
        }
        public void ReadEntries5() { //rangelow and rangehigh are cells like A1 or F12
            var range = $"{sheet}!A6:P6"; 
            var request = service.Spreadsheets.Values.Get(SpreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach(var row in values)
                {
                    Username5=($"{row[0]}");
                    Time5=($"{row[15]}");
                }
                
            }
        }
}



