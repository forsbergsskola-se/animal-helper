using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour {
    public PlayerModel playerModel;
    public int cost = 20;

    public int[] table = { 90, 6, 2, 1, 1 };
    public List<GameObject> buttons;

    // public void RollGacha() {
    //     if (!playerModel.HasEnoughGold(cost)) return;
    //     playerModel.Gold -= cost;
    //     playerModel.Inventory.Add(new Item() { Rarity = "Legendary" });
    //     ShowAllItems();
    //     // foreach(var item in GenerateRandomLoot(lootBoxConfig))
    //     //     this.playerModel.Items.Add(item);
    //     foreach(var button in buttons)
    //         button.GetComponent<Image>().color = Color.grey;
    //     GetRandomItem();
    // }
    
    // private void GetRandomItem() {
    //     var randomNumb = Random.Range(0, 100);
    //     for (int i = 0; i < table.Length; i++) {
    //         if (randomNumb <= table[i]) {
    //             buttons[i].GetComponent<Image>().color = Color.magenta;
    //             return;
    //         } else {
    //             randomNumb -= table[i];
    //         }
    //     }
    // }

    // private void ShowAllItems() {
    //     Debug.Log($"You have {playerModel.Inventory.Count} items");
    //     foreach (var item in playerModel.Inventory) {
    //         Debug.Log(item.Rarity + " tube");
    //     }
    // }

    private void ErrorMsg() {
        Debug.Log("You don't have enough gold");
    }
}