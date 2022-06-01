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
    }

    // Update is called once per frame
    void Update()
    {
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && isPillButtonClicked == false) 
            promptText.text = "- Click Pill -";


            
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        
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

    IEnumerator wakingUp() {
        Timer.hintCount = 6;
        yield return new WaitForSeconds(0.5f);
        fadeAnim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        faintedGenesis.SetActive(false);
        fadeAnim.SetTrigger("End");
        prompts.openDialogueBox(3, prompts.ActII);
        gameObject.SetActive(false);
        ObjectivesList.objective1.text = "Head up to Headquarters through elevator!";

    }
}
