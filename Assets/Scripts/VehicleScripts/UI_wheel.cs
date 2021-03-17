using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_wheel : MonoBehaviour
{

    public Sprite wheelFrame01;
    public Sprite wheelFrame02;


    private GameObject car;
    private Image image;
    private float animationSpeed = 0.5f;
    float timer = 0;
    private void Start()
    {
        image = this.GetComponent<Image>();
        StartCoroutine(Initiate());
    }

    private IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.1f);
        car = GameObject.Find("Car(Clone)");
    }

    private void FixedUpdate()
    {
        if (car != null) animateSprite();
        
        
    }



    void animateSprite()
    {
        
        timer += Time.deltaTime* car.GetComponent<Rigidbody2D>().velocity.magnitude;;
        

        if (timer >= animationSpeed)
        {
            image.sprite = switchImage();
            timer = 0;
        }
        
    }

    Sprite switchImage()
    {
        if (image.sprite == wheelFrame01) return wheelFrame02;
        return wheelFrame01;
    }
}
