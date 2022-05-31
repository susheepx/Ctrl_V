using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameCanvasController : MonoBehaviour
{
    public StoryScene currentScene;
    public GameDialogueBox dialogueBox;
    public GameObject dialogue;
    public GameObject playerInput;
    public GameObject playerInputEnterButton;
    public ElevatorButton elevatorButton;
    public List<StoryScene>  ActI, ActII, Elevator, ActIII, Hints, Warnings = new List<StoryScene>();
    public List<List<StoryScene>> listOfStorysceneLists = new List<List<StoryScene>>();
    


    private void Start() {
        listOfStorysceneLists.Add(ActI);
        listOfStorysceneLists.Add(ActII);
        listOfStorysceneLists.Add(ActIII);
        listOfStorysceneLists.Add(Hints);
        listOfStorysceneLists.Add(Warnings);
        listOfStorysceneLists.Add(Elevator);
    }


    private bool isEnterButtonClicked = false;
    public static bool isConfirmPopupOpen = false;

    public void enterButtonTrue() {
        isEnterButtonClicked = true;
    }


    //open hints list

    public GameObject hintPopup;
    private bool isHintPopup = false;
    public void openHintList() {
        if (isHintPopup == false) {
            hintPopup.SetActive(true);
        }
        else {
            hintPopup.SetActive(false);
        }

    }

    //open command list
    public GameObject commandPopup;
    private bool isCommandOpen = false;
    public void openCommandList() {
        if (isCommandOpen == false) {
            commandPopup.SetActive(true);
        }
        else {
            commandPopup.SetActive(false);
        }

    }

    // Update is called once per frame
    public void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) ||  isEnterButtonClicked) && dialogue.activeSelf == true && ElevatorButton.isInputFieldSelected == false && isConfirmPopupOpen == false )
        {
            isEnterButtonClicked = false;

            //if the slow type has finished the sentence or paragraph
            if(dialogueBox.IsCompleted())
            {
                //if the scene is finished. Last sentence refers to the last dialogue in the sentence list
                if(dialogueBox.IsLastSentence())
                {
                    if (currentScene.nextScene == null) {
                    //this makes the dialogue box dissapear after it finishes its prompt/thought
                        // dialogue.SetActive(false);
                        // playerInput.SetActive(false);
                        // Astronaut.canMove = true;
                        // if (storysceneList[2].nextScene != null && elevatorButton.sentenceGuessed) {
                        //     currentScene = storysceneList[4];
                        //     dialogueBox.PlayScene(currentScene);
                        //     elevatorButton.guessWho();

                        // }
                        // elevatorButton.checkAnswer();
                        if (currentScene != Elevator[0] && currentScene != Elevator[3] ) {
                            dialogue.SetActive(false);
                            if (currentScene != ActI[2]) {
                                Astronaut.canMove = true;
                            }
                            elevatorButton.playerInput.SetActive(false);
                        }
                        else if (currentScene == Elevator[0]) {
                            elevatorButton.checkAnswer();
                        }
                        
                        else
                        {   
                            elevatorButton.playerInput.SetActive(false);
                            elevatorButton.guessWhoCheck();
                        }

                        

                        
                        
                        
                    
                    }
                    else {
                        //this plays the next scene if there is one, most likely won't be in game screen
                        currentScene = currentScene.nextScene;
                        dialogueBox.PlayScene(currentScene);
                        if (currentScene == Elevator[3]) {
                            elevatorButton.playerInput.SetActive(true);
                        }
                    

                        
                    } 

                } 
                else {
                    dialogueBox.PlayNextSentence();
                    if (currentScene == Elevator[3]) {
                        elevatorButton.guessWho();
                    }

                }   
                    
            }
                
        }
    }

    public void openDialogueBox(int integer, List<StoryScene> storyScenes) {
        Astronaut.canMove = false;
        dialogue.SetActive(true);
        currentScene = storyScenes[integer];
        dialogueBox.PlayScene(currentScene);
        
    }


    private Inventory inventory;
    public GameObject confirmPill;
    public Astronaut astronaut;

    public void noPill() {
        GameCanvasController.isConfirmPopupOpen = false;
        dialogue.SetActive(false);
        confirmPill.SetActive(false);
        Astronaut.canMove = true;
    }

}
