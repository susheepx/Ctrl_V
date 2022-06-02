using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class keycardlock : MonoBehaviour
{
    public UI_Inventory inventory;
    public GameObject openSafe;
    public TextMeshProUGUI promptText;
    public static bool isKeycardUsed = false;
    public static bool isSafeOpen = false;
    public Animator anim;
    public static Collider2D keycardCollider;


    // Start is called before the first frame update
    void Start()
    {
        keycardCollider = gameObject.GetComponent<Collider2D>();
        //ItemWorld.SpawnItemWorld(new Vector3(-60f,80f,0), new Item { itemType = Item.ItemType.Keycard});

    }

    // Update is called once per frame
    void Update()
    {
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && isKeycardUsed == false) {
            Astronaut.shouldTextPressF = false;
            promptText.text = "- Insert Keycard -";
        }
    }


    public void insertKeycard() {
        isKeycardUsed = true;
        if (Astronaut.interact && GetComponent<Collider2D>() == Astronaut.currentItem && EventSystem.current.currentSelectedGameObject.name == "keycardIcon") 
        {
            inventory.testList();
            isSafeOpen = true;
            openSafe.SetActive(true);
            anim.SetTrigger("openSafe");
        }
            
    }

}
