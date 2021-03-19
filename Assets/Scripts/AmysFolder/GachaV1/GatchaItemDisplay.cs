using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace Gatcha
{
    public class GatchaItemDisplay : MonoBehaviour
    {
        [SerializeField]
        public class SO_Display
        {
            public Text nameText;
            public Text rarityText;
            public Image artworkImage;
            public Text amount;
        }

        public GatchaScriptableObjects[] gatchaItem = { };
        // Add var of X to be the number of which the rarity has in the list/array for it later in the desplaying.
        public Text rarityText;
        public Image artworkImage;
        public Text amount;
        public Color artworkColor;

        public void Start()
        {
           foreach(GatchaScriptableObjects i in gatchaItem)
            {
                //Debug.Log(i.gatchaItemRarity, i);
                
                rarityText.text = i.gatchaItemRarity;
                artworkImage.sprite = i.gatchaItemSprite;
                amount.text = i.gatchaItemAmount.ToString();
                artworkColor = i.rarityColor;
                artworkImage.color = i.rarityColor;
            }
        }
    }
}
