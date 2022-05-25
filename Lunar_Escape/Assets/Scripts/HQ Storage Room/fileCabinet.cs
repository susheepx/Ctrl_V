using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileCabinet : MonoBehaviour
{
    public GameObject openFileCabinet;
    private ItemWorld Keycard;
    public ItemWorld Folder;
    // Start is called before the first frame update
    private void Start() {
        openFileCabinet.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Collider2D>() == Astronaut.currentItem) {
            if (openFileCabinet.activeSelf == false) {
                openFileCabinet.SetActive(true);
                Folder = ItemWorld.SpawnItemWorld(new Vector3(49.42f,111.85f,0), new Item { itemType = Item.ItemType.Folder});
                //Keycard = ItemWorld.SpawnItemWorld(new Vector3(57.725f,4.6f,0), new Item { itemType = Item.ItemType.Keycard});
                Folder.GetComponent<BoxCollider2D>().size = new Vector2 (3.2f,1.5f);
                //Keycard.GetComponent<BoxCollider2D>().size = new Vector2 (0.62f,1.19f);
            }

            else {
                openFileCabinet.SetActive(false);
                if (Folder != null)
                    Folder.DestroySelf();
            }
        }
    }
}
