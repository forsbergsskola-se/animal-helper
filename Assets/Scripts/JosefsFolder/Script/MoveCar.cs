using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    public Text distanceText;
   
    public float speed = 5f;


    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 distance;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.transform.position;
    }
    
    private void Update()
    {
        //rb.AddForce(Vector2.right * speed);

         distance = rb.position - startPos;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance.x).ToString("D");                  
    }
    

    public void PushTheCar()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * (speed * 200));
        Debug.Log("Pushed the car! ");
    }
}
