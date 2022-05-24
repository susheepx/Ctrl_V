using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ErikaLyingDown : MonoBehaviour
{
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

    public void testPill() {
        
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "bottle3Icon") 
        {
            isPillButtonClicked = true;
            isConscious = true;
            promptText.text = " yayy";
            inventory.testList();


        }
        else if (EventSystem.current.currentSelectedGameObject.name == "bottle2Icon" || EventSystem.current.currentSelectedGameObject.name == "bottle1Icon" ) {
            promptText.text = "oops";
        }
            
    }
}
