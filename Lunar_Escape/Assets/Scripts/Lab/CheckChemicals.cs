using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckChemicals : MonoBehaviour
{
    public FadeScript fade;
    public chemicals chem;
    public List<string> guessChemicalList = new List<string>();
    public List<string> answerChemicalList = new List<string>();
    public List<GameObject> chemList = new List<GameObject>();
    public static bool isCodeSolved = false;
    public static bool isAdhesiveCollected = false;

    public GameObject adhesiveImage, popupSafe, chemCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void checkChemicals() {
    if (chemicals.numSelected == 3) {
        foreach (string chemical in guessChemicalList) {
            if (answerChemicalList.Contains(chemical)) {
                isCodeSolved = true;
        }
            else {
                isCodeSolved = false;
                Debug.Log("wrong code");
                return;
            }
            
        }
        Debug.Log("yayy u got it");
        adhesiveImage.SetActive(true);
        StartCoroutine(fade.fadeOutIn());
        StartCoroutine(waitForFade());
        


    }
    }

    public void ResetChemicals() {
        if (chemicals.numSelected == 3) {
            foreach (string chemical in guessChemicalList) {
                foreach (GameObject chemList in chemList) {
                    if (chemList.name == chemical) {
                        chem.thisChemical.normalColor = chem.thisChemical.disabledColor;
                        chem.thisChemical.selectedColor = chem.thisChemical.disabledColor;
                        chemList.GetComponent<Button>().colors = chem.thisChemical;
                        chemicals.numSelected --;
                        chemList.GetComponent<chemicals>().isSelected = false;
                        
                    }
                }
            }  
        //remove chemical selected to list
        guessChemicalList.Clear();         
        }

    }

    IEnumerator waitForFade() {
        yield return new WaitForSeconds(1.5f);
        popupSafe.SetActive(false);
        chemCanvas.SetActive(false);
        ItemWorld.SpawnItemWorld(new Vector3(-54.67f,78.4f,0), new Item { itemType = Item.ItemType.Adhesive});

        Astronaut.canMove = true;

    }
    


}
