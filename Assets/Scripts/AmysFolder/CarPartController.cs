using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPartController : MonoBehaviour
{
    // This is the one that use the values in data and place them where they need to be.
    public SpriteRenderer[] sprites; /// 0: Body, 1: Front Wheel, 2: Back Wheel, 3: Spoiler.
    public InventoryObject item;
    public UI_WheelBar wheelBar;
    public MoveCar moveCar;
    public DragButton dragButton;

    public float PushSpeed;
    public int BoostForce;
    public float Drag;
    public float WobbleAmount;
    public int Mass;
    public GameObject rigidBody;

    public void PartData()
    {

        PushSpeed = moveCar.pushSpeed;
        BoostForce = moveCar.boostForce;
        Drag = dragButton.DuckDrag;
        WobbleAmount = wheelBar.wobbleAmount;

    }
    public void SaveData()
    {
        CarPartSaveSystem.SavePlayer(this);
    }
    public void LoadData()
    {
        CarPartData data = CarPartSaveSystem.LoadCarParts();
        PushSpeed = data.pushSpeed;
        BoostForce = data.boostForce;
        Drag = data.drag;
        WobbleAmount = data.wobbleAmount;
        Mass = data.mass;
        for (var i = 0; i < sprites.Length; i++)
        {
            sprites[0].sprite = data.Body.EquipedParts[0].item.itemSprite;
            sprites[1].sprite = data.FrontWheel.EquipedParts[1].item.itemSprite;
            sprites[2].sprite = data.BackWheel.EquipedParts[2].item.itemSprite;
            sprites[3].sprite = data.Spoiler.EquipedParts[3].item.itemSprite;
        }
    }
}
