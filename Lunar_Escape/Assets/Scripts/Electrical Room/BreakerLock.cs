using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerLock : MonoBehaviour
{
    public bool isCodeSolved;
    public List<string> lockAlphaList;
    public List<string> lockSlot;
    public List<string> inputCodeList = new List<string>();
    public List<string> secretCodeList = new List<string>();



        //AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1});

    private void Start() {
    }
    public List<string> GetInputList()
    {
        return inputCodeList;
    }



    public void checkSecretCode() {
        for (int i = 0; i < secretCodeList.Count; i++) {
            if (inputCodeList[i] != secretCodeList[i])
                isCodeSolved = false;
            else
            {
                isCodeSolved = true;
            }
        }
        if (isCodeSolved)
            gameObject.SetActive(false);
    }
    
        
}
