using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerWires : MonoBehaviour
{
    public GameCanvasController prompts;
    private bool isFirstTimeOpen = true;
    public static bool isWiresOpen = false;
    public Wire wire;
    public GameObject wireGame;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Collider2D>() == Astronaut.currentItem) {
            if (isFirstTimeOpen) {
                prompts.openDialogueBox(2,prompts.ActI);
                isFirstTimeOpen = false;
                
            }
        if (isWiresOpen == false) {
            wireGame.SetActive(true);
            isWiresOpen = true;
            wire.Activate();
            wire.startSetup();
            Astronaut.canMove = false;
            
        }
        else {
            wireGame.SetActive(false);
            isWiresOpen = false;
            Astronaut.canMove = true;
        }

    }
    }
}
