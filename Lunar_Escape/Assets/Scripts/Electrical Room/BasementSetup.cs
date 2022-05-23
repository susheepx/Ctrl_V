using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementSetup : MonoBehaviour
{
    public ItemWorld bottle1;
    public ItemWorld bottle2;
    public ItemWorld bottle3;
    // Start is called before the first frame update
    void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(-0.2f,-5.6f,0), new Item { itemType = Item.ItemType.BluePrint});
        ItemWorld.SpawnItemWorld(new Vector3(3.5f,2.8f,0), new Item { itemType = Item.ItemType.BreakerNote});
        ItemWorld.SpawnItemWorld(new Vector3(91.34f,-31.17f,0), new Item { itemType = Item.ItemType.Poem});
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
        
    }
}
