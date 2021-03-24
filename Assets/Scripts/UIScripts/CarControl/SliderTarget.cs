using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderTarget : MonoBehaviour
{
    private Slider slider;

    private GameObject car;
    private Wheel wheel;

    public float targetPos;

    private float randompos;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInParent<Slider>();
        StartCoroutine(wheelPosition());
        StartCoroutine(Initiate());
    }



    void FixedUpdate()
    {

        if (car != null)
        {
            if (wheel.isOnGround) Steering();
            else ResetSteering();
            
        }
    }
    

    void Steering()
    {
        float a = Mathf.Sin(Time.time * 1.7f);
        float b = Mathf.Sin(Time.time * 4f);
        float c = Mathf.Clamp((car.GetComponent<Rigidbody2D>().velocity.x * 0.1f), 0f, 1f);

        float y = a * b * Mathf.Sin(Time.time) *0.5f;
        slider.value = Mathf.Lerp(slider.value, 0.5f + (randompos + y) * c, 0.05f) ;


        targetPos = slider.value;
    }

    void ResetSteering()
    {
        slider.value = Mathf.Lerp(slider.value, 0.5f , 0.05f) ;
    }

    IEnumerator wheelPosition()
    {
        yield return new WaitForSeconds(Random.Range(0,30f)*0.1f);
        randompos = Random.Range(-50, 50)*0.01f;
        StartCoroutine(wheelPosition());
    }

    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.1f);
        car = GameObject.Find("Car(Clone)");

        wheel = car.GetComponentInChildren<Wheel>();
    }
    
}