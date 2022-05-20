using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
    public StoryScene currentScene;
    public GameDialogueBox dialogueBox;
    public GameObject dialogue;
    public List<StoryScene> storysceneList = new List<StoryScene>();

    // Start is called before the first frame update
    void Start()
    {
        //this will start off the first dialogue box right when game initiates
        dialogueBox.PlayScene(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //if the slow type has finished the sentence or paragraph
            if(dialogueBox.IsCompleted())
            {
                //if the scene is finished. Last sentence refers to the last dialogue in the sentence list
                if(dialogueBox.IsLastSentence())
                {
                    //this makes the dialogue box dissapear after it finishes its prompt/thought
                    if (currentScene.nextScene == null)
                        dialogue.SetActive(false);
                    else
                        //this plays the next scene if there is one, most likely won't be in game screen
                        currentScene = currentScene.nextScene;
                } 
                else   
                    dialogueBox.PlayNextSentence();
            }
                
        }
    }

    public void openDialogueBox(StoryScene currentscene) {
        dialogue.SetActive(true);
        dialogueBox.PlayScene(currentscene);
    }

}
