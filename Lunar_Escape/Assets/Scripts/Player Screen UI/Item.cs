using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        BluePrint,
        BreakerNote,
        Bottle1,
        Bottle2,
        Bottle3,
        Poem,
        Folder,
        Keycard,
        Adhesive
    
    }
    public ItemType itemType;
    //take out int amount later since we are not having multiple copies of one item
    //amount= the id for the item in the inventory
    //public int amount;

    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:     return ItemAssets.Instance.blueprintSprite;
        case ItemType.BreakerNote:   return ItemAssets.Instance.breakerNoteSprite;
        case ItemType.Bottle1:       return ItemAssets.Instance.bottle1Sprite;
        case ItemType.Bottle2:       return ItemAssets.Instance.bottle2Sprite;
        case ItemType.Bottle3:       return ItemAssets.Instance.bottle3Sprite;
        case ItemType.Poem:          return ItemAssets.Instance.poemSprite;
        case ItemType.Folder:        return ItemAssets.Instance.folderSprite;
        case ItemType.Keycard:       return ItemAssets.Instance.keycardSprite;
        case ItemType.Adhesive:      return ItemAssets.Instance.adhesiveSprite;
        }
    }

    public string SpriteName() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:    return "blueprint";
        case ItemType.BreakerNote:  return "breakernote";
        case ItemType.Bottle1:      return "bottle1";
        case ItemType.Bottle2:      return "bottle2";
        case ItemType.Bottle3:      return "bottle3";
        case ItemType.Poem:         return "poem";
        case ItemType.Folder:       return "folder";
        case ItemType.Keycard:      return "keycard";
        case ItemType.Adhesive:     return "adhesive";
        }
    }

    public string InventoryName() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:    return "blueprintIcon";
        case ItemType.BreakerNote:  return "breakernoteIcon";
        case ItemType.Bottle1:      return "bottle1Icon";
        case ItemType.Bottle2:      return "bottle2Icon";
        case ItemType.Bottle3:      return "bottle3Icon";
        case ItemType.Poem:         return "poemIcon";
        case ItemType.Folder:       return "folderIcon";
        case ItemType.Keycard:      return "keycardIcon";
        case ItemType.Adhesive:     return "adhesiveIcon";

        }
    }



    
   
}
