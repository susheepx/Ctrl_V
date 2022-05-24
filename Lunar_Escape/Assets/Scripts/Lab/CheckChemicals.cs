using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckChemicals : MonoBehaviour
{
    public List<string> guessChemicalList = new List<string>();
    public List<string> answerChemicalList = new List<string>();
    public static bool isCodeSolved = false;
    public static bool isAdhesiveCollected = false;

    public GameObject adhesiveImage;

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


    }
    }

    


}
