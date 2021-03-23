using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView: MonoBehaviour {
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI nameText;
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

    public void Display(InventorySlot item) {
        this.item = item;
        amountText.text = item.amount.ToString("n0");
        nameText.text = item.item.name;
        image.sprite = item.item.itemSprite;
    }
    
    public void OnMouseDown() {
        selected = !selected;
        image.color = selected ? Color.green : ogColour;
    }

    public void AddToInv(InventoryObject inventory) {
        var parentName = transform.parent.name;
        if(parentName != "InventoryScreen") {
            inventory.AddItem(item.item, 1);
            Destroy(gameObject);
        }
    }
}