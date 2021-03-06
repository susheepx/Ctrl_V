using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Astronaut : MonoBehaviour
{
    //storyline
    public GameCanvasController prompts;
    public ItemWorld Keycard;
    public Collider2D warning1, warning2, warning3, warning5, warning6, warning7;
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
    public static bool shouldTextPressF = true;
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

    public void pillPopupOpen() {
        GameCanvasController.isConfirmPopupOpen = true;
    }
    public void yesPill() {
        GameCanvasController.isConfirmPopupOpen = false;
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


    
    public static bool isHazmatAcquired = false;

    private void Update() {


        if (canMove) {
            PlayerMoveKeyboard();
            AnimatePlayer();
        }
        else {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Front", false);
            anim.SetBool("Back", false);
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
                    pillPopupOpen();
                    Debug.Log(GameCanvasController.isConfirmPopupOpen);
                }
                else if (itemWorld.name == "bottle2") {
                    prompts.openDialogueBox(6, prompts.ActII);
                    confirmPill.SetActive(true);
                    pillPopupOpen();
                    Debug.Log(GameCanvasController.isConfirmPopupOpen);
                }
                else if (itemWorld.name == "bottle3") {
                    prompts.openDialogueBox(7, prompts.ActII);
                    confirmPill.SetActive(true);
                    pillPopupOpen();
                    Debug.Log(GameCanvasController.isConfirmPopupOpen);
                }
                
                //if the item is the hazmat suit, it doesn't add to inventory but changes the animation
                else if (itemWorld.name == "hazmat") {
                    if(CheckChemicals.isAdhesiveCollected) {
                        itemWorld.DestroySelf();
                        isHazmatAcquired = true;
                        anim.SetTrigger("HazmatOn");
                        warning1.enabled = true;
                    }
                    else {
                        prompts.openDialogueBox(4, prompts.ActIII);
                    }

                }  
                else {
                    //adds the item to inventory and destroys in game
                    inventory.AddItem(itemWorld.GetItem());
                    itemWorld.DestroySelf();
                    
                }
                //specific actions happen everytime one of these are picked up
                if (itemWorld.name == "blueprint") {
                    prompts.openDialogueBox(1, prompts.ActI);
                    BreakerButton.isBlueprintPicked = true;
                    Timer.hintCount = 1;
                }
                if (itemWorld.name == "breakernote" && ElevatorButton.isPuzzleTwoSolved) {
                    prompts.openDialogueBox(1, prompts.ActIII);

                }
                if (itemWorld.name == "folder") {
                    Keycard = ItemWorld.SpawnItemWorld(new Vector3(49.42f,110f,0), new Item { itemType = Item.ItemType.Keycard});
                    Keycard.GetComponent<BoxCollider2D>().size = new Vector2 (1f,1f);
                    prompts.openDialogueBox(2, prompts.ActIII);
                    fileCabinet.isFolderPicked = true;
                }
                if (itemWorld.name == "adhesive") {
                    CheckChemicals.isAdhesiveCollected = true;
                }
                if (itemWorld.name == "keycard") {
                    prompts.openDialogueBox(3, prompts.ActIII);
                }
                else {
                currentItem = null;
                // itemWorld = null;
                }
                
            }
            }
        }
    }
    public GameObject promptDialogue;
    public SecondTimer minigameTimer;
    private void OnTriggerEnter2D(Collider2D collider) { 
        //set local variable collider to global variable so it can be used in update
        currentItem = collider;
    
        
        //if the colliding component is an item that can go in inventory
        if (collider.GetComponent<ItemWorld>() != null){
            //open set key prompt box
            controller.SetActive(true); 
            pickUpItem = true;
            controlText.text = "- Press E -";
            
        }            
        
        
        else if (pickUpItem != true) 
        {
            if (collider == warning1) {
                if (isHazmatAcquired == false) {
                    controller.SetActive(false);
                    prompts.openDialogueBox(3, prompts.Warnings);
                    warning1.enabled = false;
                    return;
                }
                else {
                    minigameTimer.ActivateTimerFinal();
                    controller.SetActive(false);
                    ObjectivesList.objective1.text = "PATCH UP THE HOLE";
                    prompts.openDialogueBox(0, prompts.Warnings);
                    warning1.enabled = false;
                    moveForce = 8;
                    return;
                }
            }
            else if (warning2 == collider) {
                if (isHazmatAcquired) {
                    controller.SetActive(false);
                    prompts.openDialogueBox(1, prompts.Warnings);
                    warning2.enabled = false;
                    moveForce = 5;
                    return;
                }
            }
            else if (warning5 == collider) {
                if (isHazmatAcquired == false) {
                    controller.SetActive(false);
                    prompts.openDialogueBox(4, prompts.Warnings);
                    warning5.enabled = false;
                    return;
                }
            }
            else if  (warning6 == collider) {
                if (isHazmatAcquired == false) {
                    controller.SetActive(false);
                    prompts.openDialogueBox(5, prompts.Warnings);
                    return;
                }
            }
            else if (warning3 == collider) {
                if (isHazmatAcquired) {
                    controller.SetActive(false);
                    prompts.openDialogueBox(2, prompts.Warnings);
                    warning3.enabled = false;
                    moveForce = 3;
                    return;
                }
            }
            else if (warning7 == collider) {
                if (isHazmatAcquired == false) {
                    controller.SetActive(false);
                    prompts.openDialogueBox(6, prompts.Warnings);
                    StartCoroutine(coolantRoomStart());
                    return;
                }
            }
            else  {
                //is able to interact with objects such as breaker button
                interact = true;
                //open set key prompt box
                controller.SetActive(true); 
                if (Astronaut.shouldTextPressF == true) {
                    controlText.text = "- Press F -";
                }
                
            }
            
        }
        
        
    }
    
    public FadeScript fade;
    public Animator fadeBackgorund;

    IEnumerator coolantRoomStart() {

        Timer.timer += 120.0f;
        yield return new WaitForSeconds(0.75f);
        fadeBackgorund.SetTrigger("Start");
        yield return new WaitForSeconds(0.75f);
        promptDialogue.SetActive(false);
        gameObject.transform.position = warning1.transform.position + new Vector3(1f, -6.5f, 0f);
        yield return new WaitForSeconds(2.25f);
        fadeBackgorund.SetTrigger("End");
        warning1.enabled = true;

        warning5.enabled = true;
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
        else if(movementY != 0)
        {
            if(movementY < 0)
            {
                anim.SetBool("Front", false);
                anim.SetBool("Back", true);
            }
            else if (movementY > 0)
            {
                anim.SetBool("Back", false);
                anim.SetBool("Front", true);
            }
        }
        if(movementX == 0 && movementY == 0)
            {
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);
                anim.SetBool("Back", false);
                anim.SetBool("Front", false);

            }
            
        
    }
}

