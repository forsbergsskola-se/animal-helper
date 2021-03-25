using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveCar : MonoBehaviour
{
    private Text distanceText;
    private float startTime;
    public double raceLength;
    
    private int boostForce = 1000;
    public float speed = 5f;
    private bool raceStarted;
    private bool raceIsOver;
    
    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 distance;

    private Vector3 lastPosition;
    private Vector3 currentPosition;

    private void Start()
    {
        distanceText = GameObject.Find("CarDistanceText").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
        startPos = rb.transform.position;
    }
    
    private void FixedUpdate()
    {

        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -300, 300);
       
        distance = rb.position - startPos;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance.x).ToString("D");
        if (raceStarted) 
        {
            
            if (raceIsOver) {
                raceLength = Math.Round(Time.time - startTime, 2);

                Debug.Log("Race is over");
                GameObject.Find("MoneyWon").GetComponent<MoneyWon>().Money = Mathf.FloorToInt(distance.x);


                GameObject.Find("ResultPopupMenu").GetComponent<UI_menuPopUpAnim>().enabled = true;
                GameObject.Find("ResultPopupMenu").GetComponent<ResultMenu>().enabled = true;
                
                GameObject.Find("Wheelbar").GetComponent<UI_CloseAnim>().enabled = true;
                GameObject.Find("DragButton").GetComponent<UI_CloseAnim>().enabled = true;
                GameObject.Find("BoostButton").GetComponent<UI_CloseAnim>().enabled = true;
                raceStarted = false;
            }
        }
    }

    IEnumerator PositionCheck()
    {
        lastPosition = this.gameObject.transform.position;
        yield return new WaitForSeconds(0.3f);
        currentPosition = this.gameObject.transform.position;

        Vector3 movedDistance = lastPosition - currentPosition;
        if (movedDistance.magnitude < 0.05 && rb.velocity.magnitude < 0.3f && rb.velocity.magnitude > -0.3f) {raceIsOver = true;}
        
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(PositionCheck());
        
    }


    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1f);
        raceStarted = true;
        startTime = Time.time;
    }

    public void PushTheCar() {
        rb.AddForce(Vector2.right * (speed * 200));
        StartCoroutine(Initiate());
        StartCoroutine(PositionCheck());
    }
    
    public void CarBoost() {
        rb.AddForce(Vector2.right * boostForce);
    }
}