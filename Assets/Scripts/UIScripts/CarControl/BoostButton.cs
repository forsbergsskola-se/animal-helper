using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoostButton : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    public Sprite imageUp;

    public Sprite imageDown;
    public Sprite imageDisabled;

    private Image image;

    private GameObject car;
    private int boostAmount = 3;

    public Text text;
    
    private bool pressed;
    private bool flashbutton;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
        image = this.GetComponent<Image>();
        image.sprite = imageUp;
        flashbutton = true;
        StartCoroutine(Initiate());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pressed) onPressed();
        text.text = boostAmount.ToString("D");
    }


    void onPressed()
    {
        image.sprite = imageDisabled;
        timer += Time.deltaTime;
        if (timer > 5 && boostAmount > 0)
        {
            pressed = false;
            image.sprite = imageUp;
        }
        
    }


    IEnumerator Initiate()
    {
        car = GameObject.Find("Car(Clone)");
        yield return new WaitForSeconds(1.3f);
        image.sprite = imageDown;
        yield return new WaitForSeconds(0.8f);
        image.sprite = imageUp;

   

        flashbutton = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!flashbutton && !pressed && boostAmount > 0)
        {
            timer = 0;
            image.sprite = imageDown;
            car.GetComponent<MoveCar>().CarBoost();
            boostAmount--;
            pressed = true;
        }
        
        //Output the name of the GameObject that is being clicked
        //Debug.Log(name + " Game Object Click in Progress");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!flashbutton && !pressed && boostAmount > 0)
        {
            image.sprite = imageUp;
        }
    }
}
