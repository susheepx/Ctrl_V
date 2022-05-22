using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
    public StoryScene currentScene;
    public GameDialogueBox dialogueBox;
    public GameObject dialogue;
    public GameObject playerInput;
    public ElevatorButton elevatorButton;
    public List<StoryScene> storysceneList = new List<StoryScene>();

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && dialogue.activeSelf == true && ElevatorButton.isInputFieldSelected == false)
        {
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
                        if (currentScene != storysceneList[1] && currentScene != storysceneList[4] ) {
                            Debug.Log("currentscene not 1 or 4. nextscene is null");
                            dialogue.SetActive(false);
                            Astronaut.canMove = true;
                            elevatorButton.playerInput.SetActive(false);
                        }
                        else if (currentScene == storysceneList[1]) {
                            Debug.Log("check answer called again");
                            elevatorButton.checkAnswer();
                        }
                        
                        else
                        {   
                            Debug.Log("guess who should be checking");
                            elevatorButton.playerInput.SetActive(false);
                            elevatorButton.guessWhoCheck();
                        }

                        

                        
                        
                        
                    
                    }
                    else {
                        //this plays the next scene if there is one, most likely won't be in game screen
                        currentScene = currentScene.nextScene;
                        dialogueBox.PlayScene(currentScene);
                        if (currentScene == storysceneList[4]) {
                            Debug.Log("nextscene is playing and equals scene 4");
                            elevatorButton.playerInput.SetActive(true);
                        }
                    

                        
                    } 

                } 
                else {
                    dialogueBox.PlayNextSentence();
                    if (currentScene == storysceneList[4]) {
                        Debug.Log("next sentence played");
                        elevatorButton.guessWho();
                    }

                }   
                    
            }
                
        }
    }

    public void openDialogueBox() {
        Debug.Log("opendialoguebox is called");
        Astronaut.canMove = false;
        dialogue.SetActive(true);
        dialogueBox.PlayScene(currentScene);
    }

}
