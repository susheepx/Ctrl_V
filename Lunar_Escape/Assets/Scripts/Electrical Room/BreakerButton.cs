using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerButton : MonoBehaviour
{
    public Animator anim;
    private string SLIDINGDOORANIM = "activated";
    public Astronaut controlPrompt;
    public GameObject controller;
    //is breaker door opened
    private bool doorOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("breaker script activated");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && controlPrompt.activated && doorOpened == false)
        {    
            anim.SetTrigger(SLIDINGDOORANIM);
            doorOpened = true;
            ItemWorld.SpawnItemWorld(new Vector3(-5.4f,3f,0), new Item { itemType = Item.ItemType.BreakerNote, amount = 2});

        }


    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("trigger entered");
    //     controller.SetActive(true);

    // }

   
    // private void OnTriggerExit2D(Collider2D other) {
    //     Debug.Log("trigger exited");
    //     controller.SetActive(false);
    // }       
}
