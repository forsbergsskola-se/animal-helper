using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaRewardDisplay : MonoBehaviour
{
    public ItemObject item;
    public Image image;

    public void Start()
    {
    }
    public void Update()
    {
        image.sprite = item.itemSprite;
        image.color = item.itemSpriteColor;
        
    }
}
