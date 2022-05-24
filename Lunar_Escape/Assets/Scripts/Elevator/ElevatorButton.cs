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
                controller.currentScene = controller.storysceneList[1];
                controller.openDialogueBox();
                
            }
            else {
                controller.currentScene = controller.storysceneList[4];
                controller.openDialogueBox();
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
                Debug.Log("checkanswer called");
                controller.currentScene = controller.storysceneList[2];
                controller.openDialogueBox();
                sentenceGuessed = true;
                playerAnswer = "";
                playerInput.GetComponent<TMP_InputField>().text = "";
                playerInput.SetActive(false);
                
            }
            else {
                controller.currentScene = controller.storysceneList[3];
                controller.openDialogueBox();
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
            controller.currentScene = controller.storysceneList[5];
            controller.openDialogueBox();
            StartCoroutine(fadeScript.waitFadeTime());

            // Debug.Log(inventory.GetItemList());
            // foreach (Item item in inventory.GetItemList()) {
            //     inventory.RemoveItem(item);
            // }

        }
        else
        {
            controller.currentScene = controller.storysceneList[6];
            controller.openDialogueBox();
            guessWhoAnswer = "";
        }
    }

    

}
