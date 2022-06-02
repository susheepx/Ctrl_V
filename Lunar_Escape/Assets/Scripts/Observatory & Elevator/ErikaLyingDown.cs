using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ErikaLyingDown : MonoBehaviour
{
    public GameCanvasController prompts;
    public Animator fadeAnim;
    public GameObject overheatingSymbols, faintedGenesis;
    public UI_Inventory inventory;
    public TextMeshProUGUI promptText;
    public bool isPillButtonClicked = false;
    public static bool isConscious = false;

    // Start is called before the first frame update
    void Start()
    {
        Genesis.SetActive(false);
        Erika.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && isPillButtonClicked == false) {
            Astronaut.shouldTextPressF = false;
            promptText.text = "- Click Pill -";
        }


            
        
    }




    public void testPill() {
        
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "bottle3Icon") 
        {
            isPillButtonClicked = true;
            isConscious = true;
            overheatingSymbols.SetActive(false);
            StartCoroutine(wakingUp());

            inventory.testList();


        }
        else if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "bottle2Icon" || EventSystem.current.currentSelectedGameObject.name == "bottle1Icon" ) {
            prompts.openDialogueBox(2, prompts.ActII);

            inventory.testList();
        }
            
    }


    public GameObject Justin, Gabe, Genesis, Erika, dialogue;
    IEnumerator wakingUp() {
        Timer.hintCount = 6;
        yield return new WaitForSeconds(0.5f);

        //erika and genesis stand up
        fadeAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        faintedGenesis.SetActive(false);
        gameObject.SetActive(false);
        Genesis.SetActive(true);
        Erika.SetActive(true);
        fadeAnim.SetTrigger("End");
        prompts.openDialogueBox(3, prompts.ActII);
        
        ObjectivesList.objective1.text = "Head up to Headquarters through elevator!";
        

    }
}
