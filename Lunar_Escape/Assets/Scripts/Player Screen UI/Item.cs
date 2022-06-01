using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        BluePrint,
        BreakerNote,
        BreakerWireNote,
        Bottle1,
        Bottle2,
        Bottle3,
        Poem,
        Folder,
        Keycard,
        Adhesive,
        Hazmat
    
    }
    public ItemType itemType;

    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:        return ItemAssets.Instance.blueprintSprite;
        case ItemType.BreakerNote:      return ItemAssets.Instance.breakerNoteSprite;
        case ItemType.BreakerWireNote:  return ItemAssets.Instance.breakerWireNoteSprite;
        case ItemType.Bottle1:          return ItemAssets.Instance.bottle1Sprite;
        case ItemType.Bottle2:          return ItemAssets.Instance.bottle2Sprite;
        case ItemType.Bottle3:          return ItemAssets.Instance.bottle3Sprite;
        case ItemType.Poem:             return ItemAssets.Instance.poemSprite;
        case ItemType.Folder:           return ItemAssets.Instance.folderSprite;
        case ItemType.Keycard:          return ItemAssets.Instance.keycardSprite;
        case ItemType.Adhesive:         return ItemAssets.Instance.adhesiveSprite;
        case ItemType.Hazmat:           return ItemAssets.Instance.hazmatSprite;
        }
    }

    public string SpriteName() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:        return "blueprint";
        case ItemType.BreakerNote:      return "breakernote";
        case ItemType.BreakerWireNote:  return "breakerwirenote";
        case ItemType.Bottle1:          return "bottle1";
        case ItemType.Bottle2:          return "bottle2";
        case ItemType.Bottle3:          return "bottle3";
        case ItemType.Poem:             return "poem";
        case ItemType.Folder:           return "folder";
        case ItemType.Keycard:          return "keycard";
        case ItemType.Adhesive:         return "adhesive";
        case ItemType.Hazmat:           return "hazmat";
        }
    }

    public string InventoryName() {
        switch (itemType) {
        default:
        case ItemType.BluePrint:        return "blueprintIcon";
        case ItemType.BreakerNote:      return "breakernoteIcon";
        case ItemType.BreakerWireNote:  return "breakerwirenoteIcon";
        case ItemType.Bottle1:          return "bottle1Icon";
        case ItemType.Bottle2:          return "bottle2Icon";
        case ItemType.Bottle3:          return "bottle3Icon";
        case ItemType.Poem:             return "poemIcon";
        case ItemType.Folder:           return "folderIcon";
        case ItemType.Keycard:          return "keycardIcon";
        case ItemType.Adhesive:         return "adhesiveIcon";
        case ItemType.Hazmat:           return "hazmatIcon";

        }
    }    
   
}
