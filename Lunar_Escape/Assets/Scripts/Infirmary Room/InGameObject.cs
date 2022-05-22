using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameObject : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;
    public GameObject Object;
    private bool isCloseUpOpened = false;
    // Update is called once per frame

    private void Start() {
        Object.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Collider2D>() == Astronaut.currentItem && Astronaut.interact) {
                if (isCloseUpOpened == false) {
                    Object.SetActive(true);                   
                    isCloseUpOpened = true;
                }
                else {
                    Object.SetActive(false);
                    isCloseUpOpened = false;
                }

            }
    }
        
    
}
