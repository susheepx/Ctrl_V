using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeScript : MonoBehaviour
{
    public Animator anim;

    // public IEnumerator waitFadeTime() {
        // yield return new WaitForSeconds(0.3f);
        // anim.SetTrigger("Start");
        // yield return new WaitForSeconds(1);
        // astronaut.transform.position = hqElevator.transform.position + new Vector3(1f, -2.5f, 0f);
        // Astronaut.currentItem = null;
        // promptDialogue.SetActive(false);
        // UI_inventory.resetInventory();
        // ItemWorld.SpawnItemWorld(new Vector3(9f,90f,0), new Item { itemType = Item.ItemType.BreakerNote});
        // timer.StopTimer();
        // timer.StartTimer();
        // isPuzzleTwoSolved = true;
        // anim.SetTrigger("End");
        // yield return new WaitForSeconds(1);
        // prompts.openDialogueBox(0, prompts.ActIII);

    // }

    public IEnumerator fadeOutIn() {
        yield return new WaitForSeconds(.85f);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1.75f);
        anim.SetTrigger("End");
    }


}
