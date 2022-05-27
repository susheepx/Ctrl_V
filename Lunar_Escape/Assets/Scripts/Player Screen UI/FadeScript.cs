using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScript : MonoBehaviour
{
    public GameCanvasController prompts;
    public Inventory inventory;
    public Animator anim;
    public UI_Inventory UI_inventory;
    public GameObject astronaut, hqElevator, promptDialogue;

    public IEnumerator waitFadeTime() {
        yield return new WaitForSeconds(0.3f);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        astronaut.transform.position = hqElevator.transform.position + new Vector3(1f, -2.5f, 0f);
        Astronaut.currentItem = null;
        promptDialogue.SetActive(false);
        UI_inventory.resetInventory();
        //inventory.AddItem(Astronaut.staticBreakerNote);
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        prompts.openDialogueBox(0, prompts.ActIII);
    }

    public IEnumerator fadeOutIn() {
        yield return new WaitForSeconds(0.2f);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("End");
    }


}
