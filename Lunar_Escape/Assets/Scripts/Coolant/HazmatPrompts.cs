using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazmatPrompts : MonoBehaviour
{
    public GameCanvasController prompts;
    public GameObject commandPrompt;
    public Collider2D warning1, warning2, warning3, astronaut;
    
    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider);
        if (collider == astronaut) {
            if (collider == warning1) {
                Debug.Log("warning1 called");
                prompts.openDialogueBox(0, prompts.Warnings);
                commandPrompt.SetActive(false);
                warning1.GetComponent<GameObject>().SetActive(false);
                return;
            }
            else if (warning2 == collider) {
                Debug.Log("warning2 called");
                prompts.openDialogueBox(1, prompts.Warnings);
                commandPrompt.SetActive(false);
                warning2.GetComponent<GameObject>().SetActive(false);
                return;
            }
            else if  (warning3 == collider) {
                Debug.Log("warning3 called");
                prompts.openDialogueBox(2, prompts.Warnings);
                commandPrompt.SetActive(false);
                warning3.GetComponent<GameObject>().SetActive(false);
                return;
            }
        }
            
    }
}
