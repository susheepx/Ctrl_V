using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnterCollider : MonoBehaviour
{
    public static bool isFirstEnter = true;
    public GameCanvasController prompts;
    public GameObject commandPrompt;
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (isFirstEnter) {
            prompts.openDialogueBox(0, prompts.ActII);
            commandPrompt.SetActive(false);
            isFirstEnter = false;
            return;
        }
        gameObject.SetActive(false);
        
    }
}
