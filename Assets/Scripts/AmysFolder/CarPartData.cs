using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CarPartData
{
    // This will be the Data of all the Values
    // But wouldn't it work with just place all the stuff here?
    public InventoryObject Body;
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
        FrontWheel.EquipedParts[1].item.itemSprite = carPartController.sprites[1].sprite;
        BackWheel.EquipedParts[2].item.itemSprite = carPartController.sprites[2].sprite;
        Spoiler.EquipedParts[3].item.itemSprite = carPartController.sprites[3].sprite;

        //pushSpeed = carPartController.PushSpeed;
        //boostForce = carPartController.BoostForce;
        //drag = carPartController.Drag;
        // Get the Mass with get gameobject then Rigidbody2D > Mass
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
