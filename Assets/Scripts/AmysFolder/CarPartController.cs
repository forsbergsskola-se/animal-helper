using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarPartController : MonoBehaviour
{
    
    public SpriteRenderer Sprite_Body;
    public SpriteRenderer Sprite_Front;
    public SpriteRenderer Sprite_FrontWheel;
    public SpriteRenderer Sprite_BackWheel;
    public SpriteRenderer Sprite_Spoiler;

    void Start()
    {
        if (HackySave.Body != null ){
            Sprite_Body.sprite = HackySave.Body.item.itemSprite;

        }
        if (HackySave.Wheel != null)
        {
            Sprite_FrontWheel.sprite = HackySave.Wheel.item.itemSprite;
            Sprite_BackWheel.sprite = HackySave.Wheel.item.itemSprite;

        }
        if (HackySave.Front != null)
        {
            Sprite_Front.sprite = HackySave.Front.item.itemSprite;

        }
        if (HackySave.Spoiler != null)
        {
            Sprite_Spoiler.sprite = HackySave.Spoiler.item.itemSprite;

        }
        return;
    }
}

