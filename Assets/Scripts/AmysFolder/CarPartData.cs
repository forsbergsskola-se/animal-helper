using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CarPartData
{
    public InventoryObject Body;
    public InventoryObject Front;
    public InventoryObject FrontWheel;
    public InventoryObject BackWheel;
    public InventoryObject Spoiler;

    public float pushSpeed;
    public int boostForce;
    public float drag;
    public int mass;
    public float wobbleAmount;
    public CarPartData (CarPartController carPartController) //The Sprites
    {
        Body.EquipedParts[0].item.itemSprite = carPartController.sprites[0].sprite;
        Front.EquipedParts[1].item.itemSprite = carPartController.sprites[1].sprite;
        FrontWheel.EquipedParts[2].item.itemSprite = carPartController.sprites[2].sprite;
        BackWheel.EquipedParts[3].item.itemSprite = carPartController.sprites[3].sprite;
        Spoiler.EquipedParts[4].item.itemSprite = carPartController.sprites[4].sprite;
    }
    public CarPartData (MoveCar moveCar) //Stats
    {
        pushSpeed = moveCar.pushSpeed;
        boostForce = moveCar.boostForce;
    }
    public CarPartData(DragButton dragButton)
    {
        drag = dragButton.DuckDrag;
    }
    public CarPartData (UI_WheelBar uI_WheelBar)
    {
        wobbleAmount = uI_WheelBar.wobbleAmount;
    }
}
