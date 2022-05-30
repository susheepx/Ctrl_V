using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasementSetup : MonoBehaviour
{
    public Timer timer;
    public ItemWorld bottle1;
    public ItemWorld bottle2;
    public ItemWorld bottle3;
    public ItemWorld poem;
    public GameCanvasController prompts;
    public TextMeshProUGUI usernameContainer;
    public TextMeshProUGUI objective1Container, objective2Container, objective3Container;

    // Start is called before the first frame update
    void Start()
    {
        //starting electrical room prompt
        prompts.openDialogueBox(0, prompts.ActI);

        //spawn items throughout basement
        ItemWorld.SpawnItemWorld(new Vector3(-0.2f,-5.6f,0), new Item { itemType = Item.ItemType.BluePrint});
        ItemWorld.SpawnItemWorld(new Vector3(3.5f,2.8f,0), new Item { itemType = Item.ItemType.BreakerNote});
        ItemWorld.SpawnItemWorld(new Vector3(4.9f,2f,0), new Item { itemType = Item.ItemType.BreakerWireNote});
        poem = ItemWorld.SpawnItemWorld(new Vector3(91.34f,-31.8f,0), new Item { itemType = Item.ItemType.Poem});
        bottle1 = ItemWorld.SpawnItemWorld(new Vector3(68.246f,0.769f,0), new Item { itemType = Item.ItemType.Bottle1});
        bottle2 = ItemWorld.SpawnItemWorld(new Vector3(57.725f,4.6f,0), new Item { itemType = Item.ItemType.Bottle2});
        bottle3 =  ItemWorld.SpawnItemWorld(new Vector3(57.494f,-1.667f,0), new Item { itemType = Item.ItemType.Bottle3});  
        bottle1.GetComponent<BoxCollider2D>().size = new Vector2 (1.21f,0.79f);
        bottle2.GetComponent<BoxCollider2D>().size = new Vector2 (0.62f,1.19f);
        bottle3.GetComponent<BoxCollider2D>().size = new Vector2 (0.61f,1.36f);
        poem.GetComponent<BoxCollider2D>().size = new Vector2 (1.4f, 4.25f);
        
        //set username
        usernameContainer.text = UsernameWindow.username;

        //set objectives list
        ObjectivesList.objective1 = objective1Container;
        ObjectivesList.objective2 = objective2Container;
        ObjectivesList.objective3 = objective3Container;
        ObjectivesList.objective1.text = "Find clues scattered around the electrical room to unlock the door";
        ObjectivesList.objective2.text = "Escape the electrical room";

        //start timer
        timer.StartTimer();
    }
}
