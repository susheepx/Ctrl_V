using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasController : MonoBehaviour
{
    public StoryScene currentScene;
    public GameDialogueBox dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.PlayScene(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(dialogueBox.IsCompleted())
            {
                if(dialogueBox.IsLastSentence())
                {
                    currentScene = currentScene.nextScene;
                } 
                else   
                    dialogueBox.PlayNextSentence();
            }
                
        }
    }

}
