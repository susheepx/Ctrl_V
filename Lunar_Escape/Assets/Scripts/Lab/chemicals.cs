using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chemicals : MonoBehaviour
{

    public Color clickedColor;
    private ColorBlock thisChemical;
    public bool isSelected = false;
    public static int numSelected = 0;
    
    public CheckChemicals check;


    // Start is called before the first frame update
    void Start()
    {
        thisChemical = GetComponent<Button>().colors;
    }

    public void whenChemicalClicked() {
        if (numSelected < 3) {
            if (! isSelected) {
                //changes colors to make it look like its selected
                thisChemical.normalColor = clickedColor;
                thisChemical.selectedColor = clickedColor;
                GetComponent<Button>().colors = thisChemical;
                isSelected = true;
                //keeps track of selected, max 3
                numSelected ++;

                //remove chemical selected to list
                check.guessChemicalList.Add(GetComponent<Button>().name);
                return;
            }
        }
        if (isSelected) {
            thisChemical.normalColor = thisChemical.disabledColor;
            thisChemical.selectedColor = thisChemical.disabledColor;
            GetComponent<Button>().colors = thisChemical;
            isSelected = false;
            numSelected --;

            //add chemical selected to list
            check.guessChemicalList.Remove(GetComponent<Button>().name);

        }   
    }

    // public void addremoveItem() {
    //     if (! isSelected) {
    //         check.guessChemicalList.Remove(GetComponent<Button>().name);
    //         return;
    //     }
    //     check.guessChemicalList.Add(GetComponent<Button>().name);

    // }



    
}
