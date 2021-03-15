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

    public bool HasEnoughGold(int cost) {
        return Gold >= cost;
    }

    private void Start() {
        inventory.Load();
    }
    
    private void OnApplicationQuit() {
        inventory.Save();
        inventory.Container.Clear();
    }
}