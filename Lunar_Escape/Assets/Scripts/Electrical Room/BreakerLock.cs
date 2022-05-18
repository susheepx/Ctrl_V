using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerLock : MonoBehaviour
{
    public bool isCodeSolved;
    public GameObject breakerBox;
    public GameObject ElectricalDoor;
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
            if (inputCodeList[i] == secretCodeList[i])
                isCodeSolved = true;
            else
            {
                isCodeSolved = false;
                break;
            }
        }
        if (isCodeSolved)
            StartCoroutine(UnlockedBreaker());
    }
    
    IEnumerator UnlockedBreaker() {
        yield return new WaitForSeconds(0.9f);
        gameObject.SetActive(false);
        breakerBox.SetActive(false);
        ElectricalDoor.SetActive(false);
    }
        
}
