using UnityEngine;

public class Controller : MonoBehaviour {
    public PlayerModel playerModel;
    public int cost = 20;

    public void RollGacha() {
        if (!playerModel.HasEnoughGold(cost)) return;
        playerModel.Gold -= cost;
        playerModel.Inventory.Add(new Item() { Rarity = "Legendary" });
        Debug.Log($"You did a roll and have {playerModel.Gold} gold left!");
        ShowAllItems();
        // foreach(var item in GenerateRandomLoot(lootBoxConfig))
        //     this.playerModel.Items.Add(item);
    }

    private void ShowAllItems() {
        Debug.Log($"You have {playerModel.Inventory.Count} items");
        foreach (var item in playerModel.Inventory) {
            Debug.Log(item.Rarity + " tube");
        }
    }

    private void ErrorMsg() {
        Debug.Log("You don't have enough gold");
    }
}

public class Item {
    public string Rarity { get; set; }
}