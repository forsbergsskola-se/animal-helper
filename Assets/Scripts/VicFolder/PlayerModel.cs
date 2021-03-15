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

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                var item = hit.collider.GetComponent<Item>();
                if (item) {
                    inventory.AddItem(item.item, 1);
                    Destroy(hit.collider.gameObject);
                    print("Destroyed thing at " + Input.mousePosition);
                }
            }
        }
    }
    
    private void OnApplicationQuit() {
        // inventory.Save();
        inventory.Container.Clear();
    }
}