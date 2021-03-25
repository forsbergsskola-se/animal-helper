using UnityEngine;

public class CraftingController : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public int amountForFusion = 5;

    public void Fuse() {
        if (inventory.SelectedCount() >= amountForFusion) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int fuseCost = 500 * (1 + rarity);
            if (!player.HasEnoughNutsBolts(fuseCost)) return;
            player.NutsBolts -= fuseCost;
            inventory.Fusion(amountForFusion);
            Debug.Log("Fused!");
        }
    }
    
    public void GrindStack() {
        if (inventory.SelectedCount() > 0) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int amount = inventory.SelectedParts[0].amount;
            int grindCost = 30 * (1 + rarity) * amount;
            
            Debug.Log("Cost to grind: " + grindCost);
            if (!player.HasEnoughNutsBolts(grindCost)) return;
            player.NutsBolts -= grindCost;
            
            inventory.Grinder(amount);
            int scrapEarned = amount * 50 * (1 + rarity);
            player.Scrap += scrapEarned;
            Debug.Log("Grinded " + amount + " parts for " + scrapEarned);
        }
    }
    
    public void GrindSingle() {
        if (inventory.SelectedCount() > 0) {
            int rarity = inventory.SelectedParts[0].item.rarityLevel;
            int amount = 1;
            int grindCost = 30 * (1 + rarity);

            Debug.Log("Cost to grind: " + grindCost);
            if (!player.HasEnoughNutsBolts(grindCost)) return;
            player.NutsBolts -= grindCost;
            
            inventory.Grinder(amount);
            int scrapEarned = 50 * (1 + rarity);
            player.Scrap += scrapEarned;
            Debug.Log("Grinded " + amount + " part for " + scrapEarned);
        }
    }
}