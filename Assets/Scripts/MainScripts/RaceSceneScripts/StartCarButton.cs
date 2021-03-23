using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCarButton : MonoBehaviour
{
    private GameObject car;
    public int FramesDelayCarRolls = 0;

    private bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initiate());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countDown)
        {
            FramesDelayCarRolls--;
            if (FramesDelayCarRolls <= 0)
            {
                car.GetComponent<MoveCar>().PushTheCar();
                countDown = false;
                this.enabled = false;
            }
        }
    }

    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.1f);
        car = GameObject.Find("Car(Clone)");
    }


    public void StartRace()
    {
        countDown = true;
    }
}
