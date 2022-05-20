using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InfirmaryDoorLock : MonoBehaviour
{
    public TextMeshProUGUI keyboardScreenText;
    public TextMeshProUGUI currentButtonText;
    public Astronaut astronaut;
    public GameObject popUpKeypad;
    private bool keypadOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        currentButtonText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && astronaut.interact && GetComponent<Collider2D>() == astronaut.currentItem) {
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
        keyboardScreenText.text += currentButtonText.text;
    }
}
