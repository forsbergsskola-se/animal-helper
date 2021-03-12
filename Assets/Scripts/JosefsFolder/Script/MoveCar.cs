using UnityEngine;
using UnityEngine.UI;

<<<<<<< Updated upstream
public class MoveCar : MonoBehaviour {
    public Text distanceText;
=======
public class MoveCar : MonoBehaviour
{
    private Text distanceText;
>>>>>>> Stashed changes
   
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

<<<<<<< Updated upstream
    private void Start() {
=======

    private void Start()
    {
        distanceText = GameObject.Find("CarDistanceText").GetComponent<Text>();
>>>>>>> Stashed changes
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.transform.position;
    }
    
    private void Update() {
        distance = rb.position - startPos;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance.x).ToString("D");       
        if (!raceStarted) {
            CheckIfMouseButtonDown();
            CheckIfMouseButtonUp();
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