using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WheelBar : MonoBehaviour
{
    
    private Quaternion rotation;
    private Vector3 rotVector;

    public SliderTarget sliderTarget;
    public SliderSteeringWheel sliderSteeringWheel;

    public UI_wheel leftWheel;
    public UI_wheel rightWheel;
    
    private GameObject car;
    
    
    public float wobbleAmountMultiplier = 1;
    [HideInInspector]
    public float wobbleAmount;
    [HideInInspector]
    public float wobbleSpeedTimer;

    public Wheel wheel;

    private void Start()
    {
        StartCoroutine(Initiate());
    }

    void FixedUpdate()
    {
        if (car != null)
        {

                wobbleSpeedTimer += (Time.deltaTime * car.GetComponent<Rigidbody2D>().velocity.magnitude) * 3;
            
                if (wheel.isOnGround)
                {


                    wobbleAmount = sliderTarget.targetPos - sliderSteeringWheel.targetPos;
                    leftWheel.WobbleAmount = Mathf.Clamp(wobbleAmount, 0, 1);
                    rightWheel.WobbleAmount = Mathf.Abs(Mathf.Clamp(wobbleAmount, -1, 0));
                    wobbleAmount = Mathf.Abs(wobbleAmount) * wobbleAmountMultiplier;

        
                    rotVector.z = Mathf.Sin(wobbleSpeedTimer) * Mathf.Clamp(wobbleAmount, 0, 2*wobbleAmountMultiplier);
                    rotation.eulerAngles = rotVector;
                    this.transform.rotation = rotation;

                    wobbleAmount *= 0.96f;

                }
                else
                {
                    wobbleAmount *= 0.8f;
                    var rotator = (sliderTarget.targetPos - sliderSteeringWheel.targetPos)*10;
                    Debug.Log(rotator);
                    car.GetComponent<Rigidbody2D>().angularVelocity += rotator;
                    
                }
            
        }
    }
    
    private IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.15f);
        car = GameObject.Find("Car(Clone)");
        if (car != null)
        {
            
            wheel = car.GetComponentInChildren<Wheel>();
        }
        else
        {
            StartCoroutine(Initiate());
     
        }
        
        
    }

    
}
