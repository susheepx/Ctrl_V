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
    private bool cabinetOpen = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && astronaut.interact && GetComponent<Collider2D>() == astronaut.currentItem) {
            if (cabinetOpen == false) {
                popUpCabinet.SetActive(true);
                astronaut.controlText.text = "Click Item";
                bottle1 = ItemWorld.SpawnItemWorld(new Vector3(50f,3f,0), new Item { itemType = Item.ItemType.Bottle1});
                bottle2 = ItemWorld.SpawnItemWorld(new Vector3(42f,5f,0), new Item { itemType = Item.ItemType.Bottle2});
                bottle3 =  ItemWorld.SpawnItemWorld(new Vector3(50f,7f,0), new Item { itemType = Item.ItemType.Bottle3});  
                bottle1.GetComponent<SpriteRenderer>().sortingLayerName = "Game Layout";
                bottle2.GetComponent<SpriteRenderer>().sortingLayerName = "Game Layout";
                bottle3.GetComponent<SpriteRenderer>().sortingLayerName = "Game Layout";
                cabinetOpen = true; 
            }
            else {
                popUpCabinet.SetActive(false);
                if (bottle1 != null)
                    bottle1.DestroySelf();
                if (bottle2 != null)
                    bottle2.DestroySelf();
                if (bottle3 != null)
                    bottle3.DestroySelf();
                cabinetOpen = false;

            }
        }

        if (Input.GetMouseButtonDown(0)) {

        }
    }
}
