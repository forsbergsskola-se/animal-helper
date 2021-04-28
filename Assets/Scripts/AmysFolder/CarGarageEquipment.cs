using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGarageEquipment : MonoBehaviour
{
    public SpriteRenderer Sprite_Body;
    public SpriteRenderer Sprite_Front;
    public SpriteRenderer Sprite_FrontWheel;
    public SpriteRenderer Sprite_BackWheel;
    public SpriteRenderer Sprite_Spoiler;
    public InventoryObject inventory;

    public void UpdateSprites()
    {
        for (int i = 0; i < inventory.EquipedParts.Count; i++)
        {
            switch (inventory.EquipedParts[i].item.itemType)
            {
                case "Front":
                    Sprite_Front.sprite = inventory.EquipedParts[i].item.itemSprite; ;
                    break;
                case "Wheel":
                    Sprite_FrontWheel.sprite = inventory.EquipedParts[i].item.itemSprite;
                    Sprite_BackWheel.sprite = inventory.EquipedParts[i].item.itemSprite;
                    break;
                case "Body":
                    Sprite_Body.sprite = inventory.EquipedParts[i].item.itemSprite;
                    break;
                case "Spoiler":
                    Sprite_Spoiler.sprite = inventory.EquipedParts[i].item.itemSprite; ;
                    break;
            }
        }
    }
}

