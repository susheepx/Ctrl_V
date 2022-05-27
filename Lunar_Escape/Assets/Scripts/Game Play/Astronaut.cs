using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Astronaut : MonoBehaviour
{
    //storyline
    public static Item staticBreakerNote;
    private bool isAdhesiveAcquired = false;
    public GameCanvasController prompts;
    public ItemWorld Keycard;
    public Collider2D warning1, warning2, warning3;
    //player
    private float movementX;
    private float movementY;
    [SerializeField]
    private float moveForce = 10f;
    public Rigidbody2D rb;
    private Animator anim;
    public static bool canMove = true;
    //inventory
    [SerializeField] private UI_Inventory uiInventory;
    
    private Inventory inventory;
    //press key prompt
    public GameObject controller;
    //the game object that holds the text for the key prompt
    public GameObject controlTextContainer;
    private GameObject colliderGameObject;
    public TextMeshProUGUI controlText;
    //objects
    public GameObject DialoguePrompt;
    private ItemAssets itemDialogue;
    public static bool interact = false;
    public bool pickUpItem = false;
    public static Collider2D currentItem;
    
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
        if (canMove) {
            PlayerMoveKeyboard();
            AnimatePlayer();
        }
        else {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            rb.velocity = new Vector2(0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.E) && pickUpItem) {
            //checks if item is object and destroys; adds to inventory
            ItemWorld itemWorld = currentItem.GetComponent<ItemWorld>();
            if (itemWorld != null) {
                //time it is touching/around the object
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
                if (itemWorld.name == "blueprint") {
                    prompts.openDialogueBox(1, prompts.ActI);
                    Timer.hintCount ++;
                }
                if (itemWorld.name == "breakernote") {
                    staticBreakerNote = itemWorld.GetItem();
                    Debug.Log(staticBreakerNote);
                }
                if (itemWorld.name == "folder") {
                    Keycard = ItemWorld.SpawnItemWorld(new Vector3(49.42f,110f,0), new Item { itemType = Item.ItemType.Keycard});
                    Keycard.GetComponent<BoxCollider2D>().size = new Vector2 (1f,1f);
                }
                if (itemWorld.name == "adhesive") {
                    isAdhesiveAcquired = true;
                }
                pickUpItem = false; 
                currentItem = null;
            }
        }
    }

    
    private void Start() {
    }
    private void OnTriggerEnter2D(Collider2D collider) { 
        //set local variable collider to global variable so it can be used in update
        currentItem = collider;
    
        //open set key prompt box
        controller.SetActive(true); 
        //if the colliding component is an item that can go in inventory
        if (collider.GetComponent<ItemWorld>() != null){
            
            pickUpItem = true;
            controlText.text = "- Press E -";
            
        }            
        
        else if (pickUpItem != true) 
        {
            if (collider == warning1) {
                if (isAdhesiveAcquired == false) {
                    prompts.openDialogueBox(3, prompts.Warnings);
                    return;
                }
                else {
                    prompts.openDialogueBox(0, prompts.Warnings);
                    warning1.enabled = false;
                    moveForce = 4;
                    return;
                }
            }
            else if (warning2 == collider) {
                if (isAdhesiveAcquired == false) {
                    prompts.openDialogueBox(4, prompts.Warnings);
                    return;
                }
                else {
                prompts.openDialogueBox(1, prompts.Warnings);
                warning2.enabled = false;
                moveForce = 2;
                return;
                }
            }
            else if  (warning3 == collider) {
                if (isAdhesiveAcquired == false) {
                    prompts.openDialogueBox(5, prompts.Warnings);
                    return;
                }
                else {
                prompts.openDialogueBox(2, prompts.Warnings);
                warning3.enabled = false;
                moveForce = 1;
                return;
                }
            }
            else {
            //is able to interact with objects such as breaker button
            interact = true;
            controlText.text = "- Press F -";
            }
        }
        
    }

    // private void OnTriggerStay2D(Collider2D collider) {
    //     if (collider.GetComponent<ItemWorld>() != null){
    //         pickUpItem = true;
    //         controlText.text = "- Press E key -";
    //     }            
        
    //     else  
    //     {
            
    //         //is able to interact with objects such as breaker button
    //         interact = true;
    //         controlText.text = "- Press F -";
    //     }
    // }
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

