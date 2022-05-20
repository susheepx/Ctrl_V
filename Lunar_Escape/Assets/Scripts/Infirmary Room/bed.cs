using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    public Astronaut astronaut;
    public GameObject popupBed;
    private bool isBedCloseUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && astronaut.interact && GetComponent<Collider2D>() == astronaut.currentItem) {
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
