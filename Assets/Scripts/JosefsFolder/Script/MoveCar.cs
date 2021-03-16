using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MoveCar : MonoBehaviour
{
    private Text distanceText;
    
    public float speed = 5f;
    private bool raceStarted;

    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 distance;
    
//     Vector3 screenPositionStart;
//     Vector3 screenPositionEnd;
//     Vector3 screenPositionDifference;
//     float timeOffset;
//     float timeStart;

    private void Start()
    {
        distanceText = GameObject.Find("CarDistanceText").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
        startPos = rb.transform.position;
    }
    
    private void Update() {
        Debug.Log(rb.velocity.x);
        distance = rb.position - startPos;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance.x).ToString("D");       
        if (!raceStarted) {
            CheckIfMouseButtonDown();
            CheckIfMouseButtonUp();
        }
        else {
            if (rb.velocity.x < 0.3) {
                Debug.Log("Race is over");
                GameObject.Find("MoneyWon").GetComponent<MoneyWon>().Money = Mathf.FloorToInt(distance.x);
                //TODO Maybe a popup with your distance and a button for going back to the workshop
                //For now just go to garage scene
                SceneManager.LoadScene("GarageScene");
            }
        }
    }

    void CheckIfMouseButtonDown() {
        if (Input.GetMouseButtonDown(0)) {
            // screenPositionStart = Input.mousePosition;
            // timeStart = Time.time;
        }
    }

    void CheckIfMouseButtonUp() {
        if (Input.GetMouseButtonUp(0)) {
            // screenPositionEnd = Input.mousePosition;
            PushTheCar();
        }
    }

    public void PushTheCar() {
        rb.AddForce(Vector2.right * (speed * 200));
        Debug.Log("Pushed the car! ");
        raceStarted = true;
//      timeOffset = 0.1f;
//      var timeDifference = Math.Max(Time.time - timeStart, timeOffset);
//      screenPositionDifference = (screenPositionEnd - screenPositionStart) / Screen.dpi;
//      var worldDirection = Vector3.forward * screenPositionDifference.y + Vector3.right * screenPositionDifference.x;
//      rb.AddForce(worldDirection * speed);
    }
}