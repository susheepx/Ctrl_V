using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(-0.2f,-5.6f,0), new Item { itemType = Item.ItemType.BluePrint});
        ItemWorld.SpawnItemWorld(new Vector3(3.5f,2.8f,0), new Item { itemType = Item.ItemType.BreakerNote});
        ItemWorld.SpawnItemWorld(new Vector3(91.34f,-31.17f,0), new Item { itemType = Item.ItemType.Poem});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
