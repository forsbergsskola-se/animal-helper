using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
    public delegate void GoldEvent(int goldValue);
    public event GoldEvent ListenToGoldChange;
    
    private int _gold = 100;

    public int Gold {
        get => _gold;
        set {
            _gold = value;
            ListenToGoldChange?.Invoke(value);
        }
    }
    
    public List<Item> Inventory = new List<Item>() {
        new Item() { Rarity = "Common" },
        new Item() { Rarity = "Epic" },
    };
    
    public bool HasEnoughGold(int cost) {
        return Gold >= cost;
    }
}
