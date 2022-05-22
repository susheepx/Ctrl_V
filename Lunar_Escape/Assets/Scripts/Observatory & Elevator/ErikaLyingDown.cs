using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ErikaLyingDown : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public bool isPillButtonClicked = false;
    public static bool isConscious = true;

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
        isPillButtonClicked = true;
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "bottle3Icon") 
        {
            isConscious = false;
            promptText.text = " yayy";
            
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "bottle2Icon") {
            promptText.text = "oops";
        }
            
    }
}
