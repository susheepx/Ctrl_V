using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InfirmaryDoorLock : MonoBehaviour
{
    public GameCanvasController prompts;
    public TextMeshProUGUI keyboardScreenText;
    public TextMeshProUGUI currentButtonText;
    public GameObject popUpKeypad;
    public GameObject confirmPill;
    public Animator anim;
    private bool keypadOpen = false;
    private bool isKeypadSolved = false;
    // Start is called before the first frame update
    void Start()
    {
        currentButtonText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && isKeypadSolved == false) {
            if (keypadOpen == false) {
                popUpKeypad.SetActive(true);
                Astronaut.canMove = false;
                keypadOpen = true;
            }
            else {
                popUpKeypad.SetActive(false);
                keypadOpen = false;
                Astronaut.canMove = true;
            }

        }
    }

    public void keypadButtonPressed() {
        currentButtonText = EventSystem.current.currentSelectedGameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(keyboardScreenText.text);
        if (keyboardScreenText.text.Length < 5) {
            keyboardScreenText.text += currentButtonText.text;
        }
    }

    public void backButtonPressed() {
        if (keyboardScreenText.text.Length > 0)
            keyboardScreenText.text = keyboardScreenText.text.Remove(keyboardScreenText.text.Length - 1);
    }

    public void checkKeypadCode() {
        if (keyboardScreenText.text == "LUNAR") {
            keyboardScreenText.text = "correct";
            isKeypadSolved = true;
            popUpKeypad.SetActive(false);
            keypadOpen = false;
            Astronaut.canMove = true;
            anim.SetTrigger("InfirmaryDoorSlide");
            Timer.hintCount = 5;
            if (EnterCollider.isFirstObservatoryEnter == true) {
                prompts.openDialogueBox(1, prompts.ActII);
            }
        }
        else {
            keyboardScreenText.text = "";
        }
    }
}
