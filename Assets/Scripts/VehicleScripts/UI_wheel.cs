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

    private GameObject car;
    private Image image;
    private float animationSpeed = 0.5f;

    public float Wear;
    
    public float WobbleAmount;
    public SliderTarget sliderTarget;
    public SliderSteeringWheel sliderSteeringWheel;
    public bool LeftWheel;


    public UI_WheelBar wheelBar;
    
    private float timer = 0;
    private void Start()
    {
        image = this.GetComponent<Image>();
        StartCoroutine(Initiate());
    }

    private IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.15f);
        car = GameObject.Find("Car(Clone)");
        if (car == null) {StartCoroutine(Initiate());}
    }

    private void FixedUpdate()
    {
        if (car != null)
        {
            timer += (Time.deltaTime * car.GetComponent<Rigidbody2D>().velocity.magnitude) * 3;
            if (LeftWheel) wheelBar.wobbleSpeedTimer = timer;
            animateSprite();
            Wobble();
        }
    }


    void Wobble()
    {
        
        WobbleAmount = sliderTarget.targetPos - sliderSteeringWheel.targetPos;
       
        if (LeftWheel)
        {
            WobbleAmount = Mathf.Clamp(WobbleAmount, 0, 1);
          

        }
        else
        {
            WobbleAmount = Mathf.Abs(Mathf.Clamp(WobbleAmount, -1, 0));
        }

        
        if (WobbleAmount > 0.5f) wheelBar.wobbleAmount += WobbleAmount*0.2f;
   
        
        
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
