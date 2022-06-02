using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameObject : MonoBehaviour
{
    public GameObject Object;
    public static bool isCloseUpOpened = false;
    // Update is called once per frame

    private void Start() {
        Object.SetActive(false);
    }
    void Update()
    {
        if (GetComponent<Collider2D>() == Astronaut.currentItem && Astronaut.interact) {
            Astronaut.shouldTextPressF = true;
            if (Input.GetKeyDown(KeyCode.F)) {
                
                if (isCloseUpOpened == false) {
                    Astronaut.canMove = false;
                    Object.SetActive(true);

                    isCloseUpOpened = true;
                }
                else {
                    Astronaut.canMove = true;
                    Object.SetActive(false);
                    isCloseUpOpened = false;
                }
            }

        }
    }
        
    
}
