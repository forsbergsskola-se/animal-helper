using UnityEngine;
using UnityEngine.UI;

public class GachaPopup : MonoBehaviour {
    public Image image;
    public Image rarityImage;
    public Color[] rarityColors;
    public Image[] rarityPNG;
    
    public void ClaimButton() {
        Destroy(gameObject);
    }

    public void ColorDisplay(InventorySlot item) {
        rarityImage.color = rarityColors[item.item.rarityLevel];
    }
}