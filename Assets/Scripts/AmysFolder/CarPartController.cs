using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class CarPartController : MonoBehaviour
{
    
    public SpriteRenderer Sprite_Body;
    public SpriteRenderer Sprite_Front;
    public SpriteRenderer Sprite_FrontWheel;
    public SpriteRenderer Sprite_BackWheel;
    public SpriteRenderer Sprite_Spoiler;

    public Sprite[] sprites;

    // Change by the InventoryObject by the switch.
    public static InventorySlot FirstWheel;
    public static InventorySlot SecondWheel;
    public static InventorySlot Front;
    public static InventorySlot Body;
    public static InventorySlot Spoiler;

    // Picks the Data from CarPartData and place in above.
    /*
    public  InventorySlot _FirstWheel;
    public  InventorySlot _SecondWheel;
    public  InventorySlot _Front;
    public  InventorySlot _Body;
    public  InventorySlot _Spoiler;
    

    // Stats
    public float PushSpeed; // Front
    public int BoostForce; // Body
    public float Drag; // Spoiler
    public float WobbleAmount; // Front Wheel & Back Wheel

    public void Awake()
    {
        //Save Sprites though My Data Save
        /*
        Sprite_Body.sprite = Body.item.itemSprite;
        Sprite_Front.sprite = Front.item.itemSprite;
        Sprite_FrontWheel.sprite = FirstWheel.item.itemSprite;
        Sprite_BackWheel.sprite = SecondWheel.item.itemSprite;
        Sprite_Spoiler.sprite = Spoiler.item.itemSprite;

        //Save Sprites though Hacky Save
        Sprite_Body.sprite = HackySave.Body.item.itemSprite;
        Sprite_Front.sprite = HackySave.Front.item.itemSprite;
        Sprite_FrontWheel.sprite = HackySave.FirstWheel.item.itemSprite;
        Sprite_BackWheel.sprite = HackySave.SecondWheel.item.itemSprite;
        Sprite_Spoiler.sprite = HackySave.Spoiler.item.itemSprite;
        
    }
    public void SaveDataStart()
    {
        /*
        Debug.Log("SaveDataStart Sprite Saved");
        Sprite_Body.sprite = Body.item.itemSprite;
        Sprite_Front.sprite = Front.item.itemSprite;
        Sprite_FrontWheel.sprite = FirstWheel.item.itemSprite;
        Sprite_BackWheel.sprite = SecondWheel.item.itemSprite;
        Sprite_Spoiler.sprite = Spoiler.item.itemSprite;
        
        Debug.Log("Saved Stats Data");
        PushSpeed = Front.item.PushSpeed;
        BoostForce = Body.item.BoostForce;
        Drag = Spoiler.item.Drag;
        WobbleAmount = FirstWheel.item.WobbleAmount;
        WobbleAmount = SecondWheel.item.WobbleAmount;

    }
    public void SaveData()
    {

        Debug.Log("Saved Data");
        CarPartSaveSystem.SavePlayer(this);
    }
    public void LoadData()
    {
        Debug.Log("Load Data");
        CarPartData data = CarPartSaveSystem.LoadCarParts();

        Sprite_Body.sprite = data.Body.sprite;
        Sprite_Front.sprite = data.Front.sprite;
        Sprite_FrontWheel.sprite = data.FirstWheel.sprite;
        Sprite_BackWheel.sprite = data.SecondWheel.sprite;
        Sprite_Spoiler.sprite = data.Spoiler.sprite;

        // Stats
        PushSpeed = data.PushSpeed;
        BoostForce = data.BoostForce;
        Drag = data.Drag;
        WobbleAmount = data.WobbleAmount;

        /*
        // Sprites
        FirstWheel = data.FirstWheel;
        SecondWheel = data.SecondWheel;
        Front = data.Front;
        Body = data.Body;
        Spoiler = data.Spoiler;
        
    }
}
*/
