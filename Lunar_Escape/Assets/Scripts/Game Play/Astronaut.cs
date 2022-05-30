using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Astronaut : MonoBehaviour
{
    //storyline
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
    public GameObject controller, confirmPill;
    
    //public GameObject controlTextContainer;
    public TextMeshProUGUI controlText;
    //objects
    public static bool interact = false;
    public bool pickUpItem = false;
    public static Collider2D currentItem;
    public static ItemWorld itemWorld;
    
    private void Awake() {
        //astronaut
        anim = GetComponent<Animator>();
        //controlText = controlTextContainer.GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(true);

        //inventory
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
    }

    public void yesPill() {
        prompts.dialogue.SetActive(false);
        if (prompts.currentScene = prompts.ActII[5]) {
            inventory.AddItem(Astronaut.itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
        else if (prompts.currentScene = prompts.ActII[6]) {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
        else if (prompts.currentScene = prompts.ActII[7]) {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
        confirmPill.SetActive(false);
        canMove = true;
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
        //when E key pressed pick up item
        if (Input.GetKeyDown(KeyCode.E) && pickUpItem) {
            
            if (currentItem != null) {
                ItemWorld currentWorld = currentItem.GetComponent<ItemWorld>();
                itemWorld = currentWorld;
            
            
            if (itemWorld != null) {
                //if item is one of the pills, ask for confirmation first
                if (itemWorld.name == "bottle1") {
                    prompts.openDialogueBox(5, prompts.ActII);
                    confirmPill.SetActive(true);
                }
                else if (itemWorld.name == "bottle2") {
                    prompts.openDialogueBox(6, prompts.ActII);
                    confirmPill.SetActive(true);
                }
                else if (itemWorld.name == "bottle3") {
                    prompts.openDialogueBox(7, prompts.ActII);
                    confirmPill.SetActive(true);
                }    
                else {
                    //adds the item to inventory and destroys in game
                    Debug.Log(itemWorld);
                    Debug.Log(itemWorld.GetItem().SpriteName());
                    inventory.AddItem(itemWorld.GetItem());
                    itemWorld.DestroySelf();
                    
                }
                //specific actions happen everytime one of these are picked up
                if (itemWorld.name == "blueprint") {
                    prompts.openDialogueBox(1, prompts.ActI);
                    Timer.hintCount ++;
                }
                if (itemWorld.name == "breakernote" && ElevatorButton.isPuzzleTwoSolved) {
                    prompts.openDialogueBox(1, prompts.ActIII);
                }
                if (itemWorld.name == "folder") {
                    Keycard = ItemWorld.SpawnItemWorld(new Vector3(49.42f,110f,0), new Item { itemType = Item.ItemType.Keycard});
                    Keycard.GetComponent<BoxCollider2D>().size = new Vector2 (1f,1f);
                }
                if (itemWorld.name == "adhesive") {
                    isAdhesiveAcquired = true;
                }
                if (itemWorld.name == "keycard") {
                    prompts.openDialogueBox(3, prompts.ActIII);
                }
                // currentItem = null;
                // itemWorld = null;
                
            }
            }
        }
    }

    public SecondTimer minigameTimer;
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
                    minigameTimer.ActivateTimerFinal();
                    prompts.openDialogueBox(0, prompts.Warnings);
                    warning1.enabled = false;
                    moveForce = 9;
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
                moveForce = 4;
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
                moveForce = 2;
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

