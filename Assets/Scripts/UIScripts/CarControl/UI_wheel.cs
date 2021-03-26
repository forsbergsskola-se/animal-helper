using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_wheel : MonoBehaviour
{

    public Sprite wheelFrame01;
    public Sprite wheelFrame02;

    private Quaternion rotation;
    private Vector3 rotVector;


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
        
        rotVector.z = Mathf.Sin(timer) * (WobbleAmount * 30);
        rotation.eulerAngles = rotVector;
        this.transform.rotation = rotation;
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
