using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class UI_wheel : MonoBehaviour
{

    public Sprite wheelFrame01;
    public Sprite wheelFrame02;

    private Quaternion rotation;
    private Vector3 rotVector;
    
    public AudioSource WheelWobbleSound;
    public AudioSource WheelWobbleSound2;
    public bool playSound;


    private Image image;

    //public float Wear;
    [HideInInspector]
    public float WobbleAmount;
    


    public UI_WheelBar wheelBar;
    
    private float timer = 0;
    private void Start()
    {
        image = this.GetComponent<Image>();
     
    }


    private void FixedUpdate()
    {
        timer = wheelBar.wobbleSpeedTimer;
            animateSprite();
            Wobble();
        
    }


    void Wobble()
    {
        if (WobbleAmount > 0.3f) wheelBar.wobbleAmount += WobbleAmount*0.2f;
        WheelWobbleSound.volume = Mathf.Clamp(WobbleAmount, 0, 1);
        WheelWobbleSound2.volume = WheelWobbleSound.volume;
        rotVector.z = Mathf.Sin(timer) * (WobbleAmount * 30);
        rotation.eulerAngles = rotVector;
        this.transform.rotation = rotation;

        if (Mathf.Sin(timer) >= 0.9f && playSound)
        {
            playSound = false;
            WheelWobbleSound2.pitch = Random.Range(1f, 1.5f);
            WheelWobbleSound2.Play();
        }
        
        if (Mathf.Sin(timer) < 0.9f && !playSound)
        {
            playSound = true;
            WheelWobbleSound.pitch = Random.Range(0.5f, 1f);
            WheelWobbleSound.Play();
        }
    }

    void animateSprite()
    {
        if (Mathf.Sin(timer) > 0)
        {
            image.sprite = wheelFrame01;
        }
        else
        {
            image.sprite = wheelFrame02;
        }
        
    }
    
}
