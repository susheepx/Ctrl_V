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
                controller.openDialogueBox(0, controller.Elevator);
                
            }
            else {
                controller.openDialogueBox(3, controller.Elevator);
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
                controller.openDialogueBox(1, controller.Elevator);
                sentenceGuessed = true;
                playerAnswer = "";
                playerInput.GetComponent<TMP_InputField>().text = "";
                playerInput.SetActive(false);
                
            }
            else {
                controller.openDialogueBox(2, controller.Elevator);
            }
        isPoemSentenceDialogue = false;
        }
    }

    public void guessWho() { 
        playerGuessWhoAnswer += playerInput.GetComponent<TMP_InputField>().text;
        playerInput.GetComponent<TMP_InputField>().text = "";
        playerInput.SetActive(true);
        Debug.Log(playerGuessWhoAnswer);
    }

   

    public void guessWhoCheck() {
        playerGuessWhoAnswer += playerInput.GetComponent<TMP_InputField>().text;
        if (playerGuessWhoAnswer.Equals(guessWhoAnswer, System.StringComparison.OrdinalIgnoreCase)) {
            controller.openDialogueBox(4, controller.Elevator);
            StartCoroutine(waitFadeTime());
            
        }
        else
        {
            controller.openDialogueBox(5, controller.Elevator);
            playerGuessWhoAnswer = "";
        }
    }

    public UI_Inventory UI_inventory;
    public GameObject astronaut, hqElevator, promptDialogue;
    public Animator anim;
    public static bool isPuzzleTwoSolved = false;
    public Timer timer;
    public GameCanvasController prompts;


    public IEnumerator waitFadeTime() {
        //going from elevator to hq elevator
        yield return new WaitForSeconds(0.3f);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        astronaut.transform.position = hqElevator.transform.position + new Vector3(1f, -2.5f, 0f);
        Astronaut.currentItem = null;
        promptDialogue.SetActive(false);
        playerInput.SetActive(false);
        UI_inventory.resetInventory();
        ItemWorld.SpawnItemWorld(new Vector3(9f,90f,0), new Item { itemType = Item.ItemType.BreakerNote});
        Timer.hintCount = 8;
        timer.StopTimer();
        isPuzzleTwoSolved = true;
        anim.SetTrigger("End");

        //start of hq dialogue "hears hissing noise". all crewmates should be standing there
        yield return new WaitForSeconds(1);
        prompts.openDialogueBox(0, prompts.ActIII);
        yield return new WaitForSeconds(1.75f);

        //crewmates ask "where is that noise coming from"
        dialogueBox.PlayNextSentence();
        yield return new WaitForSeconds(2f);

        //"let's go check it out"
        dialogueBox.PlayNextSentence();
        StartCoroutine(fadeScript.fadeOutIn());
        //during this coroutine should have crewmates fade out 
        yield return new WaitForSeconds(1.75f);

        //you are alone, the others have left to go check out noise. "Wait up"
        dialogueBox.PlayNextSentence();
        StartCoroutine(cutSceneActIII());

    }

    public GameObject coolantCollider;
    public GameDialogueBox dialogueBox;
    public GameObject mainCam;
    public GameObject panCam;
    private IEnumerator cutSceneActIII() {
        promptDialogue.SetActive(true);
        
        //move from elevator to outside coolant room
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("Start");
        astronaut.transform.position = coolantCollider.transform.position;
        anim.SetTrigger("End");

        //captain telling crewmates to "be careful, they don't know what's inside"
        dialogueBox.PlayNextSentence();
        yield return new WaitForSeconds(3.25f);

        //hears a thud
        dialogueBox.PlayNextSentence();
        StartCoroutine(fadeScript.fadeOutIn());
        yield return new WaitForSeconds(2.5f);

        //"guys are you ok"
        dialogueBox.PlayNextSentence();
        yield return new WaitForSeconds(2f);

        //"....."
        dialogueBox.PlayNextSentence();
        yield return new WaitForSeconds(1.75f);
        mainCam.SetActive(false);
        panCam.SetActive(true);
        yield return new WaitForSeconds(3f);
        panCam.SetActive(false);
        mainCam.SetActive(true);
        yield return new WaitForSeconds(1.75f);

        //"i think i heard a pipe burst earlier"
        dialogueBox.PlayNextSentence();
        yield return new WaitForSeconds(2.5f);

        //"I can't risk going in there, I have to find something to seal pipe burst"
        dialogueBox.PlayNextSentence();
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(fadeScript.fadeOutIn());
        promptDialogue.SetActive(false);
        timer.StartTimer();
        
    }

    
    

}
