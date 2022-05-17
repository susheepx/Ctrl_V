using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerLock : MonoBehaviour
{
    public List<Sprite> lockSpriteList;
    public List<string> lockAlphaList;
    private List<string> inputCodeList;
    private List<string> secretCodeList;

    public BreakerLock() {
        inputCodeList = new List<string>();

        inputCodeList.Add("J");
        inputCodeList.Add("J");
        inputCodeList.Add("J");
        inputCodeList.Add("J");

        //AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1});

    }

    private void Update() {
        if (inputCodeList == secretCodeList)
            Debug.Log("secret unlocked");

    }
    public List<string> GetInputList()
    {
        return inputCodeList;
    }
}
