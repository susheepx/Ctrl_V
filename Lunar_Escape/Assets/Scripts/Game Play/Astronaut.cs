using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Astronaut : MonoBehaviour
{
    //player
    private float movementX;
    private float movementY;
    [SerializeField]
    private float moveForce = 10f;
    public Rigidbody2D rb;
    private Animator anim;
    //inventory
    [SerializeField] private UI_Inventory uiInventory;
    
    private Inventory inventory;
    //press key prompt
    public GameObject controller;
    //the game object that holds the text for the key prompt
    public GameObject controlTextContainer;
    private TextMeshProUGUI controlText;
    //objects
    public bool interact = false;
    public bool pickUpItem = false;
    public Collider2D currentItem;
    
    private void Awake() {
        //astronaut
        anim = GetComponent<Animator>();
        controlText = controlTextContainer.GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(true);

        //inventory
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
    }

    private void Update() {
        PlayerMoveKeyboard();
        AnimatePlayer();
        if (Input.GetKeyDown(KeyCode.E) && pickUpItem) {
            //checks if item is object and destroys; adds to inventory
            ItemWorld itemWorld = currentItem.GetComponent<ItemWorld>();
            if (itemWorld != null) {
                //time it is touching/around the object
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf(); 
                }
        }
    }
    private void Start() {
        ItemWorld.SpawnItemWorld(new Vector3(6,-1f,0), new Item { itemType = Item.ItemType.BluePrint, amount = 1});
        // ItemWorld.SpawnItemWorld(new Vector3(-3,9,0), new Item { itemType = Item.ItemType.Coin, amount = 1});
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        //set local variable collider to global variable so it can be used in update
        currentItem = collider;
        //open set key prompt box
        controller.SetActive(true); 
        //if the colliding component is an item that can go in inventory
        if (collider.GetComponent<ItemWorld>() != null){
            pickUpItem = true;
            controlText.text = "- Press E key -";
        }            
        
        else  
        {
            
            //is able to interact with objects such as breaker button
            interact = true;
            controlText.text = "- Press F -";
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.GetComponent<ItemWorld>() != null){
            pickUpItem = true;
            controlText.text = "- Press E key -";
        }            
        
        else  
        {
            
            //is able to interact with objects such as breaker button
            interact = true;
            controlText.text = "- Press F -";
        }
    }
    private void OnTriggerExit2D(Collider2D collider) {
        controller.SetActive(false);
        pickUpItem = false;
        // checks if item is able to be picked up
        if (collider.GetComponent<ItemWorld>() == null)
        {
            //is not able to destroy object and add it to inventory, prevents script in update to run
            interact = false;
        }
    }


    
    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        if(movementY != 0 && movementX == 0)
            rb.velocity = new Vector2(0f, movementY) * moveForce;
        else if(movementX != 0)
        {
            rb.velocity = new Vector2(movementX, 0f) * moveForce;
        }
        else
            rb.velocity = new Vector2(0f, 0f);
    
    }

    void AnimatePlayer() {
        if(movementX != 0)
        {
            if(movementX < 0)
            {
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);
            }
            else if (movementX > 0)
            {
                anim.SetBool("Left", false);
                anim.SetBool("Right", true);
            }
        }
        if(movementX == 0 && movementY == 0)
            {
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);

            }
            
        
    }
}

