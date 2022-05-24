using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Animator anim;
    public GameObject astronaut, hqElevator, promptDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator waitFadeTime() {
        yield return new WaitForSeconds(0.3f);
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        astronaut.transform.position = hqElevator.transform.position + new Vector3(1f, -2.5f, 0f);
        Astronaut.currentItem = null;
        promptDialogue.SetActive(false);
        anim.SetTrigger("End");
        Astronaut.canMove = true;
    }


}
