using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{

    public bool isOnGround;
    private bool countAirTimer;
    private float airTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countAirTimer) airTimer++;
        if (airTimer > 10) isOnGround = false;
        else isOnGround = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            airTimer = 0;
            countAirTimer = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {

        countAirTimer = true;
    }
}
