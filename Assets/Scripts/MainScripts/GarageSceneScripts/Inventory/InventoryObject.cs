using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject {
    public List<InventorySlot> Container = new List<InventorySlot>();
    public List<InventorySlot> SelectedParts = new List<InventorySlot>();
    public List<InventorySlot> EquipedParts = new List<InventorySlot>();
    private const string SavePath = "invSave";
    public int claimAmountOfTimes;
    
    public void GachaBlurController() {
        claimAmountOfTimes++;
    }
    
    public void BlurReset() {
        claimAmountOfTimes = 0;
    }

    public void AddItem(ItemObject item, int amount, int level) {
        var newSlot = new InventorySlot(item, amount, level);
        var slot = TryGetExistingInvSlot(newSlot);
        
        if (slot == null) {
            Container.Add(newSlot);
        } else {
            slot.AddAmount(amount);
        }
        
        // for (int i = 0; i < Container.Count; i++) {
        //     if (Container[i].item == _item) {
        //         Container[i].AddAmount(_amount);
        //         return;
        //     }
        // }
        // Container.Add(new InventorySlot(_item, _amount));
    }
    
    public void AddToSelected(InventorySlot item) {
        SelectedParts.Clear();
        if (item.selected) {
            SelectedParts.Add(new InventorySlot(item.item, item.amount, item.level));
        }
        
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == item.item && Container[i].level != item.level || Container[i].item != item.item) {
                Container[i].selected = false;
            }
        }
    }

    public void AddToEquiped() {
        var slot = TryGetExistingInvSlot(SelectedParts[0]);
        var newSlot = new InventorySlot(slot.item, 1, slot.level);
        slot.selected = false;
        SelectedParts.Clear();
        
        for (int i = 0; i < EquipedParts.Count; i++) {
            if (EquipedParts[i].item.itemType == newSlot.item.itemType) {
                EquipedParts[i] = newSlot;
                SaveEquippedParts();
                return;
            }
        }
        EquipedParts.Add(newSlot);
        SaveEquippedParts();
    }

    public void SaveEquippedParts() {
        for (int i = 0; i < EquipedParts.Count; i++) {
            switch (EquipedParts[i].item.itemType) {
                case "Body":
                    HackySave.Body= EquipedParts[i];
                    break;
                case "Wheel":
                    HackySave.Wheel = EquipedParts[i];
                    break;
                case "Front":
                    HackySave.Front = EquipedParts[i];
                    break;
                case "Spoiler":
                    HackySave.Spoiler = EquipedParts[i];
                    break;
            }
        }
    }

    public int SelectedCount() {
        var isEmpty = !SelectedParts.Any();
        return isEmpty ? 0 : SelectedParts[0].amount;
    }

    public void Fusion(int _amount) {
        var _item = SelectedParts[0].item;
        SelectedParts.Clear();

        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == _item) {
                Container[i].selected = false;
                Container[i].ReduceAmount(_amount);
            }
        }
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == _item.nextRarityObject) {
                Container[i].AddAmount(1);
                return;
            }
        }
        Container.Add(new InventorySlot(_item.nextRarityObject, 1, 0));
    }
    
    public void Grinder(int amount) {
        var slot = TryGetExistingInvSlot(SelectedParts[0]);
        slot.selected = false;
        slot.ReduceAmount(amount);

        SelectedParts.Clear();
    }
    
    public void LevelUp() {
        var slot = TryGetExistingInvSlot(SelectedParts[0]);
        var newSlot = new InventorySlot(slot.item, 1, slot.level + 1);
        slot.selected = false;
        slot.ReduceAmount(1);
        

        if (TryGetExistingInvSlot(newSlot) == null)
        {
            Container.Add(newSlot);
        }
        else
        {
            TryGetExistingInvSlot(newSlot).AddAmount(1);
        }
        SelectedParts.Clear();
    }

    public void Save() {
        string saveData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString(SavePath,saveData);
        
        // File.WriteAllText(Path.Combine(Application.persistentDataPath,savePath), saveData);
    }

    public void Load() {
    /*
        if (PlayerPrefs.HasKey(SavePath)) {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(SavePath), this);
        }
    */
    }

    private InventorySlot TryGetExistingInvSlot(InventorySlot slot) {
        foreach (var inventorySlot in Container) {
            if (inventorySlot.Matches(slot)) {
                return inventorySlot;
            }
        }
        return null;
    }
}

[System.Serializable]
public class InventorySlot {
    public ItemObject item;
    public int amount;
    public int level;
    public bool selected;

    public InventorySlot(ItemObject item, int amount, int level) {
        this.item = item;
        this.amount = amount;
        this.level = level;
    }

    public void AddAmount(int value) {
        amount += value;
    }
    public void ReduceAmount(int value) {
        amount -= value;
    }

    public bool Matches(InventorySlot other) {
        return other.item == this.item && other.level == this.level;
    }
}