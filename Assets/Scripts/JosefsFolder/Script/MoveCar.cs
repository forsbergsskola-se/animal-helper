using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    public Text distanceText;
   
    public float speed = 5f;
    public float turnSpeed = 2f;
    private float horizontalInput;
    private Rigidbody rb;
    private Vector3 startPos;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = rb.transform.position;
    }
    
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector3.forward * speed);
        //Vector3 forwardMove = transform.forward * speed; 

        // rb.transform.position = startPos;
        var distance = rb.transform.position - startPos;
        distanceText.text = distance.ToString();                  
    }

    private void FixedUpdate()
    {
        var horizontalMove = transform.right * horizontalInput * (speed / 20) * Time.fixedDeltaTime * turnSpeed;
        rb.MovePosition(rb.position + horizontalMove);
    }

    public void PushTheCar()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector3.forward * (speed * 200));
        Debug.Log("Pushed the car! ");
    }
}
