using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPartController : MonoBehaviour
{
    public SpriteRenderer[] sprites; /// 0: Body, 1: Front Wheel, 2: Back Wheel, 3: Spoiler.
    public InventoryObject item;
    /// Ideas & Notes
    /// Add a Button that is eneabled when an item is selected. Name: "Equip" to Car.
    /// Read the selected button and then add that to the part list. Hmmmm how does it know what part is what?...
    public void PartSpawner()
    {
        for(var i = 0; i < sprites.Length; i++)
        {
            item.Container[i].item.itemSprite = sprites[i].sprite;

        }
    }
}
