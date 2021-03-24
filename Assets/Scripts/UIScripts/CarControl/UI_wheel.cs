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

    //public float Wear;
    [HideInInspector]
    public float WobbleAmount;
    


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
            wheelBar.wobbleSpeedTimer = timer;
            animateSprite();
            Wobble();
        }
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
