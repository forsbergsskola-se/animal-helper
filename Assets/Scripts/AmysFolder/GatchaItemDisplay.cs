using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace Gatcha
{
    public class GatchaItemDisplay : MonoBehaviour
    {
        public GatchaScriptableObjects[] gatchaItem = { };
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
