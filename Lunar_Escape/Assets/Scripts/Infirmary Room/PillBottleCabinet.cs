using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottleCabinet : MonoBehaviour
{
  
    public Astronaut astronaut;
    public GameObject popUpCabinet;
    public ItemWorld bottle1;
    public ItemWorld bottle2;
    public ItemWorld bottle3;
    public bool cabinetOpen = false;
    // Start is called before the first frame update
    void Start()
    {
            bottle1 = ItemWorld.SpawnItemWorld(new Vector3(68.246f,0.769f,0), new Item { itemType = Item.ItemType.Bottle1});
            bottle2 = ItemWorld.SpawnItemWorld(new Vector3(57.725f,4.6f,0), new Item { itemType = Item.ItemType.Bottle2});
            bottle3 =  ItemWorld.SpawnItemWorld(new Vector3(57.494f,-1.667f,0), new Item { itemType = Item.ItemType.Bottle3});  
            bottle1.GetComponent<BoxCollider2D>().size = new Vector2 (1.21f,0.79f);
            bottle2.GetComponent<BoxCollider2D>().size = new Vector2 (0.62f,1.19f);
            bottle3.GetComponent<BoxCollider2D>().size = new Vector2 (0.61f,1.36f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && astronaut.interact && GetComponent<Collider2D>() == astronaut.currentItem) {

            if (cabinetOpen == false) {
                popUpCabinet.SetActive(true);
                // bottle1.GetComponent<SpriteRenderer>().sortingLayerName = "Game Layout";
                // bottle2.GetComponent<SpriteRenderer>().sortingLayerName = "Game Layout";
                // bottle3.GetComponent<SpriteRenderer>().sortingLayerName = "Game Layout";

                // bottle3.GetComponent<BoxCollider2D>().offset = new Vector2 (0f, 0.5f);

                cabinetOpen = true; 
            }
            else {
                popUpCabinet.SetActive(false);
                // if (bottle1 != null)
                //     bottle1.DestroySelf();
                // if (bottle2 != null)
                //     bottle2.DestroySelf();
                // if (bottle3 != null)
                //     bottle3.DestroySelf();
                cabinetOpen = false;

            }
        }

        
    }
}
