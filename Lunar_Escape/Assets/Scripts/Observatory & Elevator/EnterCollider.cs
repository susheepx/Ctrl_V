using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnterCollider : MonoBehaviour
{
    public GameObject astronaut;
    public static bool isFirstObservatoryEnter = true;
    public GameCanvasController prompts;
    public Collider2D obsCollider;
    public GameObject commandPrompt;
    public int numInStorysceneList;
    public int numInListofLists;
    




    private void OnTriggerEnter2D(Collider2D collider) {
        if (astronaut.GetComponent<Collider2D>() == collider) {


            //specifically for observatory enter collider

            if (GetComponent<Collider2D>() == obsCollider) {
                if (isFirstObservatoryEnter) {
                    prompts.openDialogueBox(0, prompts.ActII);
                    commandPrompt.SetActive(false);
                    isFirstObservatoryEnter = false;
                    return;
                }
                gameObject.SetActive(false);
            }


            //general collider for mainly filler rooms and maybe a few others

            else
            {
               prompts.openDialogueBox(numInStorysceneList, prompts.listOfStorysceneLists[numInListofLists]);
               return;
            }
            gameObject.SetActive(false);


        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        }
    }
}
