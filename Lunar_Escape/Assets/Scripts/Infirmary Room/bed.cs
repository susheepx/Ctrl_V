using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    public GameObject popupBed;
    private bool isBedCloseUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem) {
            if (isBedCloseUp == false) {
                popupBed.SetActive(true);
                isBedCloseUp = true;
            }
            else {
                popupBed.SetActive(false);
                isBedCloseUp = false;
            }
        }
    }
}
