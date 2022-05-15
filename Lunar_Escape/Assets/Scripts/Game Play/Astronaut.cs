using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    private float movementX;
    private float movementY;
    [SerializeField]
    private float moveForce = 10f;
    private Animator anim;
    [SerializeField] private UI_Inventory uiInventory;


    private Inventory inventory;
    public Rigidbody2D rb;
    private void Awake() {
        //astronaut
        anim = GetComponent<Animator>();
        gameObject.SetActive(true);

        //inventory
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        //test
        ItemWorld.SpawnItemWorld(new Vector3(1,8), new Item { itemType = Item.ItemType.HealthPotion, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-1,3), new Item { itemType = Item.ItemType.ManaPotion, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-3,9), new Item { itemType = Item.ItemType.Coin, amount = 1});
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.GetComponent<ItemWorld>());
        if (collider.GetComponent<ItemWorld>() != null)
            {
            ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
            if (itemWorld != null) {
                //time it is touching/around the object
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf(); 
                }
            } 
        else 
            Debug.Log("not an item");  
    }


    private void Update() {
        PlayerMoveKeyboard();
        AnimatePlayer();
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

