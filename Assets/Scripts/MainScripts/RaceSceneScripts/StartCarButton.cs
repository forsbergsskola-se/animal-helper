using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCarButton : MonoBehaviour
{
    private GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Initiate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(0.1f);
        car = GameObject.Find("Car(Clone)");
    }


    public void StartRace()
    {
        car.GetComponent<MoveCar>().PushTheCar();
    }
}
