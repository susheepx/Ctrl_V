using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerButton : MonoBehaviour
{
    private Animator anim;
    private string SLIDINGDOORANIM = "activated";
    private bool ButtonCanBePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("breaker script activated");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ButtonCanBePressed)
            anim.SetTrigger(SLIDINGDOORANIM);


    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("trigger entered");
        ButtonCanBePressed = true;

    }

   
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("trigger exited");
        ButtonCanBePressed = false;
    }       
}
