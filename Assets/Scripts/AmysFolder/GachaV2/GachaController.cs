using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GachaController : MonoBehaviour
{
    // public GachaRaritySOlist rarityList;
    //
    // public PlayerModel player;
    // public int[] RaritysWeight = { 50, 40, 30, 20, 10, 2 };
    // public int rollCost = 20;
    // public int rewardAmount = 3;
    // private float posX;
    // public void RollGacha()
    // {
    //     if (!player.HasEnoughGold(rollCost)) return;
    //     player.NutsBolts -= rollCost;
    //     posX = 0;
    //     for (int j = 0; j < rewardAmount; j++)
    //     {
    //         var totalWeights = RaritysWeight.Sum();
    //         var random = Random.Range(0, totalWeights);
    //
    //         var total = RaritysWeight[0];
    //         var i = 0;
    //         while (total < random)
    //         {
    //             i++;
    //             total += RaritysWeight[i];
    //         }
    //
    //         // Debug.Log(player.gachaLootTable[i].name);
    //         // Instantiate(player.gachaLootTable[i], new Vector3(posX, 0, 0), Quaternion.identity);
    //         posX += 1.5f;
    //     }
    // }
}
