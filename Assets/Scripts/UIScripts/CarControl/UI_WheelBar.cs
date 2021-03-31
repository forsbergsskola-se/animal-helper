using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WheelBar : MonoBehaviour
{
    public CarStatsMath stats;

    private Quaternion rotation;
    private Vector3 rotVector;

    public SliderTarget sliderTarget;
    public SliderSteeringWheel sliderSteeringWheel;

    public UI_wheel leftWheel;
    public UI_wheel rightWheel;
    
    private GameObject car;

    public AudioSource wheelRollSound;
    
    
    public float AirControlAmount = 50;
    
    public float wobbleAmountMultiplier = 1;
    //[HideInInspector]
    public float wobbleAmount = 2;
    //[HideInInspector]
    public float wobbleSpeedTimer;

    public Wheel FrontWheel;
    public Wheel BackWheel;

    public bool BothWheelsOnGround;
    private void Start()
    {
        wobbleAmount = stats.WobbleAmount;
        StartCoroutine(Initiate());
    }

    void FixedUpdate()
    {
        if (car != null)
        {
                wobbleSpeedTimer += (Time.deltaTime * car.GetComponent<Rigidbody2D>().velocity.magnitude) * 3;
            
                if (FrontWheel.isOnGround && BackWheel.isOnGround)
                {
                    wheelRollSound.volume = Mathf.Clamp((car.GetComponent<Rigidbody2D>().velocity.magnitude)/5, 0, 1);
                    wheelRollSound.pitch = Mathf.Clamp((car.GetComponent<Rigidbody2D>().velocity.magnitude)/15, 0.5f, 2);

                    BothWheelsOnGround = true;

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
                    BothWheelsOnGround = false;
                    
                    wobbleAmount *= 0.8f;
                    var rotator = (sliderSteeringWheel.targetPos-0.5f)*AirControlAmount;
                    car.GetComponent<Rigidbody2D>().angularVelocity -= rotator;
                    wheelRollSound.volume *= 0.095f;
                }
            
        }
    }
    
    private IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.15f);
        car = GameObject.Find("Car(Clone)");
        if (car != null)
        {
            
            var wheels = car.GetComponentsInChildren<Wheel>();
            FrontWheel = wheels[0];
            BackWheel = wheels[1];
        }
        else
        {
            StartCoroutine(Initiate());
     
        }
        
        
    }

    
}
