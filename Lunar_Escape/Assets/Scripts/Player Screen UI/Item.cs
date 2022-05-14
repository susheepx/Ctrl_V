using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        Sword,
        HealthPotion,
        ManaPotion,
        Coin,
        Medkit
    }

    public ItemType itemType;
    //take out int amount later since we are not having multiple copies of one item
    public int amount;
}
