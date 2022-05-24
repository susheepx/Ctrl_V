using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class keycardlock : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    public bool isKeycardUsed = false;
    public bool isSafeOpen = false;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && isKeycardUsed == false) 
            promptText.text = "- Insert Keycard -";
    }

    public void insertKeycard() {
        isKeycardUsed = true;
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "keycardIcon") 
        {
            isSafeOpen = true;
            promptText.text = " safe opened ";
            anim.SetTrigger("openSafe");
        }
            
    }

}
