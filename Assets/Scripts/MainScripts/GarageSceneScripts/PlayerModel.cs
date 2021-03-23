using UnityEngine;

public class PlayerModel : MonoBehaviour {
    public InventoryObject inventory;
    public delegate void GoldEvent(int goldValue);
    public event GoldEvent ListenToGoldChange;
    private int _gold = 100;
    
    public InventorySlot[] gachaLootTable;

    public int Gold {
        get => _gold;
        set {
            _gold = value;
            PlayerPrefs.SetInt("Gold", value);
            ListenToGoldChange?.Invoke(value);
        }
    }

    public bool HasEnoughGold(int cost) {
        return Gold >= cost;
    }

    private void Start() {
        Gold = PlayerPrefs.GetInt("Gold");
        inventory.Load();
    }

    public void AddMoney() {
        Gold += 60;
    }

    private void OnApplicationQuit() {
        inventory.Save();
        inventory.Container.Clear();
    }
}