using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView: MonoBehaviour {
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI nameText;
    public Image image;
    private bool selected;
    private Color ogColour;

    private void Start() {
        ogColour = image.color;
    }

    public void Display(InventorySlot item){
        amountText.text = item.amount.ToString("n0");
        nameText.text = item.item.name;
    }
    
    public void OnMouseDown() {
        selected = !selected;
        image.color = selected ? Color.black : ogColour;
    }

    public void AddToInv(InventoryObject inventory) {
        var parentName = transform.parent.name;
        if(parentName != "InventoryScreen") {
            var item = GetComponent<Item>();
            if (item) {
                inventory.AddItem(item.item, 1);
                Destroy(gameObject);
            }
        }
    }
}