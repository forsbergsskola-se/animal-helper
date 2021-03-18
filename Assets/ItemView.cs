using TMPro;
using UnityEngine;

public class ItemView: MonoBehaviour {
    public TextMeshProUGUI amountText;
    public TextMeshProUGUI nameText;

    public void Display(InventorySlot item){
        amountText.text = item.amount.ToString("n0");
        nameText.text = item.item.name;
    }
}