using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gurney : MonoBehaviour
{
    public GameObject popupGurney;
    private bool isGurneyCloseUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem) {
            if (isGurneyCloseUp == false) {
                popupGurney.SetActive(true);
                isGurneyCloseUp = true;
            }
            else {
                popupGurney.SetActive(false);
                isGurneyCloseUp = false;
            }
        }
    }
}
