using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
namespace Gatcha
{
    [System.Serializable]

    [SerializeField]
    public class SO_Display
    {
        public Text nameText;
        public Text rarityText;
        public Image artworkImage;
        public Text amount;
    }
    public class GatchaCalculator : MonoBehaviour
    {
        public int total;
        public int randomNumber;
        public int rewardAmount = 3;
        public List<GatchaScriptableObjects> gachaList;

        //List of the Desplay of the Items
        public Text[] nameText;
        public Text[] rarityText;
        public Image[] artworkImage;
        public Text[] amount;

        public int[] GatchaTableDropRate = { 40, 30, 20, 8, 2 };
        //Rarity: White: Common, Green: Uncommon, Blue: Rare, Purple: Epic, Gold: Legendary
        //White: 30, Green: 40, Blue: 20, Purple: 8, Gold: 2

        public void GachaRoll()
        {
            //public SO_Display[] displays;
            //randomNumber = Random.Range(0, totalWeights);
            //Debug.Log("Total Weight " + totalWeights);
            var totalWeights = GatchaTableDropRate.Sum();
            //var randomNumber = Random(0, totalWeights);
            Debug.Log("Random Number " + randomNumber);
            var total = GatchaTableDropRate[0];
            var i = 0;
            /*
            for(i = 0; i < GatchaTableDropRate.Length; i++)
            {
                if (GatchaTableDropRate[i] >= randomNumber)
                {
                    Debug.Log("You got " + GatchaTableDropRate[i]);
                }
            }
            */
            while (total < randomNumber)
            {
                i++;
                total += GatchaTableDropRate[i];
                Debug.Log("Gacha Drop " + GatchaTableDropRate[i]);
            }
            
            
        }
        
    }
}


/*
        
for (int d = 0; d < rewardAmount; d++)
            {
                

                for (int i = 0; i < GatchaTableDropRate.Length; i++)
                {
                    if (randomNumber <= GatchaTableDropRate[i])
                    {
                        nameText[d].text = gachaList[i].name;
                        rarityText[d].text = gachaList[i].gatchaItemRarity;
                        artworkImage[d].sprite = gachaList[i].gatchaItemSprite;
                        gachaList[d].gatchaItemAmount++;
                        amount[d].text = gachaList[i].gatchaItemAmount.ToString();
                        artworkImage[d].color = gachaList[i].rarityColor;
                        return;
                    }
                    else
                    {
                        randomNumber -= GatchaTableDropRate[i];
                    }
                }
            }

//Ask for SO to get the item and set possition binded to parent object
        //Make a libary with all of the pices that is in need for the building. (Question is Preformence?)
        //Sepret the Gatcha and the Garach should work fine with helping the preformence. Unsure about the objects tho and the grafical limits.
        //Make the Choosing of the texture for each piece.
        //Item need model, texture, possition, binding to set parent, rotation, mid point, mass
        //Make SOs for each car piece?

        //Make Arrays for all the Pieces in Display. Text rarity, Image sprite, Text amount ++, color for the sprite.
        //Each rarity should be able to hold there own thing.
        //public string[] rarities; //Call for its name + Color

        //List of the Desplay of the Items
        
        public Text[] nameText;
        public Text[] rarityText;
        public Image[] artworkImage;
        public Text[] amount;
        
// Version 1:
        public int[] amounts;
        public int[] chances;
        public string[] titles;
        public string[] descriptions;

        // Version 2
        [Serializable]
        public class GachaItem{
          public int amount;
          public int chance;
          public string title;
          public string descriptions;
        }

public GachaItem[] items;
            In version 1:
            amounts: 7
            chances: 1
            titles: 100
            descriptions: 0
            items: 5 or 7 or anything else
            Code now:
            int[] weights = {40, 30, 20, 10, 0}
            var roll = int.Random(0, weights[0])
            for(i = 0; i < weights.Length; i++){
               if(weights[i] >= roll)
                  // it is item i
            }
            Code with weight system:
            int[] weights = {10, 10, 10, 10, 10};
            var totalWeights = weights.Sum(); // use linq, it adds all values together. Result: 50
            var random = int.Random(0, totalWeights); // between 0 and 50, this maybe is 31

            var total = weights[0]; // starts at 10
            var i = 0; // index starts at 0
            while(total < random){
               i++; // 1 || 2 || 3
               total += weights[i]; // 20 || 30 || 40
            }

            Why do systems prefer weights over chances?
            If there's 100 items
            And legendaries have 0.1% chance and rares 5% and epics 10% or so
            Then it's really difficult for designers to make it have a sum of 100%
            It's easier to say:
            legendary weight = 1
            rareWeight = 50
            epic Weight = 100


void BuyLootBox(string lootBoxId){
 var lootBoxConfig = lootBoxesScriptableObject.GetLootbox(lootBoxId);
    if(!this.player.hasEnoughGold(lootBoxConfig.costs))
        return new Error();
        this.player.Gold -= lootBoxConfig.costs;
   foreach(var item in GenerateRandomLoot(lootBoxConfig))
        this.player.Items.Add(item);
}

// ItemInventoryView:
    void OnEnable() => this.itemStashModel.OnItemAdded += CreateItemView;
    void CreateItemView(Item item){
        var itemView = Instantiate(prefab);
        itemView.SetItem(item);
    }

// ItemView:
   void SetItem(Item item){
        item.OnCountChnanged += UpdateCount;
        this.image.sprite = item.sprite;
        this.rarityImage.color = item.rarity.color;
  }
*/
