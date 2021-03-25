using UnityEngine;

public class CraftingController : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public int amountForFusion = 5;
    public int resourcePerPart = 100;

    public void Fuse() {
        if (inventory.SelectedCount() >= amountForFusion && inventory.CanFuse()) {
            inventory.Fusion(amountForFusion);
            Debug.Log("Fused!");
        }
    }
    
    public void GrindStack() {
        if (inventory.SelectedCount() > 0) {
            int partsGrinded = inventory.GrinderStack();
            Debug.Log("Grinded: " + partsGrinded);
            player.Scrap += partsGrinded * resourcePerPart;
        }
    }
    
    public void GrindSingle() {
        if (inventory.SelectedCount() > 0) {
            int partsGrinded = inventory.GrinderSingle();
            Debug.Log("Grinded: " + partsGrinded);
            player.Scrap += partsGrinded * resourcePerPart;
        }
    }
}