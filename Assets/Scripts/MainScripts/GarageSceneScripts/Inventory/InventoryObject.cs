using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject {
    public List<InventorySlot> Container = new List<InventorySlot>();
    public List<InventorySlot> SelectedParts = new List<InventorySlot>();
    private const string savePath = "invSave";
    public int claimAmountOfTimes;
    
    public void GachaBlurController() {
        claimAmountOfTimes++;
    }
    
    public void BlurReset() {
        claimAmountOfTimes = 0;
    }

    public void AddItem(ItemObject _item, int _amount) {
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == _item) {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(_item, _amount));
    }
    
    public void AddToSelected(ItemObject _item, int _amount) {
        SelectedParts.Clear();
        
        if (_item.selected) {
            SelectedParts.Add(new InventorySlot(_item, _amount));
        }
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item != _item) {
                Container[i].item.selected = false;
            }
        }
    }
    
    public int ItemCount(ItemObject _item) {
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == _item) {
                return Container[i].amount;
            }
        }
        return 0;
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
                Container[i].item.selected = false;
                Container[i].ReduceAmount(_amount);
            }
        }
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == _item.nextRarityObject) {
                Container[i].AddAmount(1);
                return;
            }
        }
        Container.Add(new InventorySlot(_item.nextRarityObject, 1));
    }
    
    public void Grinder(int _amount) {
        var _item = SelectedParts[0].item;
        
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].item == _item) {
                Container[i].item.selected = false;
                Container[i].ReduceAmount(_amount);
            }
        }
        SelectedParts.Clear();
    }
    
    public void Save() {
        string saveData = JsonUtility.ToJson(this, true);
        PlayerPrefs.SetString(savePath,saveData);
        
        // File.WriteAllText(Path.Combine(Application.persistentDataPath,savePath), saveData);
    }

    public void Load() {
        if (PlayerPrefs.HasKey(savePath)) {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(savePath), this);
        }
    }
}

[System.Serializable]
public class InventorySlot {
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount) {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value) {
        amount += value;
    }
    public void ReduceAmount(int value) {
        amount -= value;
    }
}