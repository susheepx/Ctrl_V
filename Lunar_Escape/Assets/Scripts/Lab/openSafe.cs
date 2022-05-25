using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSafe : MonoBehaviour
{
    public GameObject chemicalCanvas;
    public GameObject adhesive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Collider2D>() == Astronaut.currentItem && Astronaut.interact) {
                if (InGameObject.isCloseUpOpened == false) {
                    //SchemicalCanvas.SetActive(true);
                    adhesive.SetActive(false);
                }
                else {
                    chemicalCanvas.SetActive(false);
                    if (CheckChemicals.isCodeSolved == true)
                        adhesive.SetActive(false);
                        if (CheckChemicals.isAdhesiveCollected == false) {
                            ItemWorld.SpawnItemWorld(new Vector3(-54.67f,78.4f,0), new Item { itemType = Item.ItemType.Adhesive});
                            CheckChemicals.isAdhesiveCollected = true;
                        }

                }

            }
    }
}
