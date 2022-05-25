using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorButton : MonoBehaviour
{
    
    public FadeScript fadeScript;
    public GameCanvasController controller;
    public GameObject playerInput;
    public static bool isInputFieldSelected = false;
    public static bool isPoemSentenceDialogue = false;
    public bool sentenceGuessed = false;
    public string playerAnswer;
    private string playerGuessWhoAnswer;
    private string guessWhoAnswer = "thestarshighreachfor";

    // Start is called before the first frame update
    void Start()
    {
        playerInput.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && isInputFieldSelected == false) {
            if (sentenceGuessed == false) {
                controller.openDialogueBox(1, controller.storysceneList);
                
            }
            else {
                controller.openDialogueBox(4, controller.storysceneList);
                playerAnswer = "";
                playerInput.GetComponent<TMP_InputField>().text = "";
            }
            playerInput.SetActive(true);
        }
    }
    public void Selected() {
        isInputFieldSelected = true;
    }
    public void notSelected() {
        isInputFieldSelected = false;
        playerAnswer = playerInput.GetComponent<TMP_InputField>().text;
        isPoemSentenceDialogue = true;
    }

    public void checkAnswer() {
        if (isPoemSentenceDialogue) {
            if (playerAnswer.Equals("reach high for the stars", System.StringComparison.OrdinalIgnoreCase)) {
                controller.openDialogueBox(2, controller.storysceneList);
                sentenceGuessed = true;
                playerAnswer = "";
                playerInput.GetComponent<TMP_InputField>().text = "";
                playerInput.SetActive(false);
                
            }
            else {
                controller.openDialogueBox(3, controller.storysceneList);
            }
        isPoemSentenceDialogue = false;
        }
    }

    public void guessWho() { 
        playerGuessWhoAnswer += playerInput.GetComponent<TMP_InputField>().text;
        playerInput.GetComponent<TMP_InputField>().text = "";
        playerInput.SetActive(true);
        Debug.Log("calling guess who");
        Debug.Log(playerGuessWhoAnswer);
    }

   

    public void guessWhoCheck() {
        Debug.Log("guesswhocheck called");
        playerGuessWhoAnswer += playerInput.GetComponent<TMP_InputField>().text;
        if (playerGuessWhoAnswer.Equals(guessWhoAnswer, System.StringComparison.OrdinalIgnoreCase)) {
            controller.openDialogueBox(5, controller.storysceneList);
            StartCoroutine(fadeScript.waitFadeTime());

        }
        else
        {
            controller.openDialogueBox(6, controller.storysceneList);
            guessWhoAnswer = "";
        }
    }

    

}
