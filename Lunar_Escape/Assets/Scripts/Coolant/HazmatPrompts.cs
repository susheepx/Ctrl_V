using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazmatPrompts : MonoBehaviour
{
    public static bool isFirstEnter = true;
    public GameCanvasController prompts;
    public GameObject commandPrompt;
    public Collider2D warning1, warning2, warning3;
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (isFirstEnter) {
            prompts.openDialogueBox(0, prompts.Warnings);
            commandPrompt.SetActive(false);
            isFirstEnter = false;
            return;
        }
        gameObject.SetActive(false);
        
    }
}
