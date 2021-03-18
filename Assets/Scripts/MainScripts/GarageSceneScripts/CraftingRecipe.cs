using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount {
    public ItemObject item;
    [Range(1,10)]
    public int amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject {
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    private bool CanCraft(InventoryObject inventory) {
        foreach (var itemAmount in Materials) {
            if (inventory.ItemCount(itemAmount.item) < itemAmount.amount) {
                Debug.Log("Can't craft");
                return false;
            }
        }
        Debug.Log("Can craft");
        return true;
    }

    public void Craft(InventoryObject inventory) {
        if (CanCraft(inventory)) {
            foreach (var itemAmount in Materials) {
                inventory.RemoveItem(itemAmount.item, itemAmount.amount);
            }
            foreach (var itemAmount in Results) {
                inventory.AddItem(itemAmount.item, itemAmount.amount);
            }
        }
    }
}
