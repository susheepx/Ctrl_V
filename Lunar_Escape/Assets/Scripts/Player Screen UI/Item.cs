using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        BluePrint,
        BreakerNote,
        ManaPotion,
        Coin,
        Medkit
    }

    public ItemType itemType;
    //take out int amount later since we are not having multiple copies of one item
    //amount= the id for the item in the inventory
    public int amount;

    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:    return ItemAssets.Instance.blueprintSprite;
        case ItemType.BreakerNote: return ItemAssets.Instance.breakerNoteSprite;
        case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
        case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
        case ItemType.Medkit:       return ItemAssets.Instance.medKitSprite;
        }
    }

    public string SpriteName() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:    return "blueprint";
        case ItemType.BreakerNote:  return "breakernote";
        case ItemType.ManaPotion:   return "item3";
        case ItemType.Coin:         return "item4";
        case ItemType.Medkit:       return "item5";
        }
    }

    public string InventoryName() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:    return "blueprintIcon";
        case ItemType.BreakerNote:  return "breakernoteIcon";
        case ItemType.ManaPotion:   return "item3Icon";
        case ItemType.Coin:         return "item4Icon";
        case ItemType.Medkit:       return "item5Icon";
        }
    }

}
