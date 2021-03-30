using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView: MonoBehaviour {
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Image image;
    private bool selected;
    private Color ogColour;
    [SerializeField] private InventorySlot item;
    
    private void Start() {
        ogColour = image.color;
        if (this.item != null) {
            Display(this.item);
        }
    }

    public void Update() {
        selected = item.selected;
        image.color = selected ? Color.green : ogColour;
    }
    
    public void Display(InventorySlot item) {
        this.item = item;
        amountText.text = item.amount.ToString("n0");
        nameText.text = item.item.name;
        image.sprite = item.item.itemSprite;
        levelText.text = item.level.ToString("n0");
    }
    
    public void SelectPart(InventoryObject inventory) {
        var parentName = transform.parent.name;
        if (parentName != "InventoryScreen") return;
        item.selected = !item.selected;
        inventory.AddToSelected(item);
    }

    public void AddToInv(InventoryObject inventory) {
        var parentName = transform.parent.name;
        if(parentName != "InventoryScreen") {
            inventory.AddItem(item.item, 1, 0);
            inventory.GachaBlurController();
        }
    }
    
    private void OnApplicationQuit() {
        item.selected = false;
    }
}