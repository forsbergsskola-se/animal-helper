using System.Collections;
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
    


    private void Start()
    {
        distanceText = GameObject.Find("CarDistanceText").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
        startPos = rb.transform.position;
        
       
     
    }
    
    private void Update() 
    {

        
       
        distance = rb.position - startPos;
        distanceText.text = "Distance: " + Mathf.FloorToInt(distance.x).ToString("D");
        if (raceStarted) 
        {
            if (rb.velocity.x < 0.4) 
            {
                Debug.Log("Race is over");
                GameObject.Find("MoneyWon").GetComponent<MoneyWon>().Money = Mathf.FloorToInt(distance.x);


                GameObject.Find("ResultPopupMenu").GetComponent<UI_menuPopUpAnim>().enabled = true;
                
                GameObject.Find("Wheelbar").GetComponent<UI_CloseAnim>().enabled = true;
                GameObject.Find("DragButton").GetComponent<UI_CloseAnim>().enabled = true;
                GameObject.Find("BoostButton").GetComponent<UI_CloseAnim>().enabled = true;
 
            }
        }
    }




    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1f);
        raceStarted = true;
    }

    public void PushTheCar() {
        rb.AddForce(Vector2.right * (speed * 200));
        
        StartCoroutine(Initiate());
    }
}