using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Item tempItem;

    private void Awake() {
    }
    public void SetInventory(Inventory inventory) {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
        RefreshInventoryItems();
    
    }
    private void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        string name;
        float itemSlotCellSize = 110f;
        foreach (Item item in inventory.GetItemList()) {
            //adjust this to fit the inventory animation
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            name = item.InventoryName();
            itemSlotRectTransform.name = name;
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            y++;
            if (y>6) {
                y = 0;
                x++;
            }
        }
    }

    public void resetInventory() {
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        inventory.clearList();

    }


    public GameObject openSafe;
    public void testList() {
        foreach (Item item in inventory.GetItemList()) {
            if(item.InventoryName() == EventSystem.current.currentSelectedGameObject.name && item.InventoryName() == "bottle3Icon" || item.InventoryName() == "bottle2Icon" || item.InventoryName() == "bottle1Icon" || item.InventoryName() == "keycardIcon" || item.InventoryName() == "adhesiveIcon") {
                tempItem = item;
                if (item.InventoryName() == "keycardIcon") {
                    openSafe.SetActive(true);
                }
            }
        }
        inventory.RemoveItem(tempItem);
    }
}
