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
    public List<StoryScene> itemPickedUpList = new List<StoryScene>();
    public List<StoryScene> promptsList = new List<StoryScene>();

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
                            dialogue.SetActive(false);
                            Astronaut.canMove = true;
                            elevatorButton.playerInput.SetActive(false);
                        }
                        else if (currentScene == storysceneList[1]) {
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
                        if (currentScene == storysceneList[4]) {
                            elevatorButton.playerInput.SetActive(true);
                        }
                    

                        
                    } 

                } 
                else {
                    dialogueBox.PlayNextSentence();
                    if (currentScene == storysceneList[4]) {
                        elevatorButton.guessWho();
                    }

                }   
                    
            }
                
        }
    }

    public void openDialogueBox(int integer, List<StoryScene> storyScenes) {
        Debug.Log("opendialoguebox is called");
        Astronaut.canMove = false;
        dialogue.SetActive(true);
        currentScene = storyScenes[integer];
        dialogueBox.PlayScene(currentScene);
        
    }

}
