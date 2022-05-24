using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InfirmaryDoorLock : MonoBehaviour
{
    public TextMeshProUGUI keyboardScreenText;
    public TextMeshProUGUI currentButtonText;
    public GameObject popUpKeypad;
    public Animator anim;
    private bool keypadOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        currentButtonText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem) {
            if (keypadOpen == false) {
                popUpKeypad.SetActive(true);
                keypadOpen = true;
            }
            else {
                popUpKeypad.SetActive(false);
                keypadOpen = false;
            }

        }
    }

    public void keypadButtonPressed() {
        currentButtonText = EventSystem.current.currentSelectedGameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(keyboardScreenText.text);
        if (keyboardScreenText.text.Length < 5) {
            keyboardScreenText.text += currentButtonText.text;
            checkKeypadCode();
        }
    }

    public void checkKeypadCode() {
        if (keyboardScreenText.text == "LUNAR") {
            keyboardScreenText.text = "correct";
            popUpKeypad.SetActive(false);
            keypadOpen = false;
            anim.SetTrigger("InfirmaryDoorSlide");
        }
        else if (keyboardScreenText.text.Length == 5) {
            keyboardScreenText.text = "";
        }
    }
}