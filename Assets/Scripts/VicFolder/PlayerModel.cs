using UnityEngine;

public class PlayerModel : MonoBehaviour {
    public InventoryObject inventory;
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
    
    // private Inventory inventory;
    // public List<Item> Inventory = new List<Item>() {
    //     new Item() { Rarity = "Common" },
    //     new Item() { Rarity = "Epic" },
    // };
    //
    // private void Awake() {
    //     inventory = new Inventory();
    // }

    public bool HasEnoughGold(int cost) {
        return Gold >= cost;
    }
}
