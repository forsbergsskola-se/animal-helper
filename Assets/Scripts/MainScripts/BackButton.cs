using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    //PointerEventData eventData
    float timeSinceClick = 1;
    string currentScene;
    void Awake() {
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update() {
         
        timeSinceClick += Time.deltaTime;
        
        if(Input.GetKey(KeyCode.Escape))
        {
            if (timeSinceClick < 1) 
            {
                Application.Quit();
            }
            
            switch (currentScene) {
                case "GarageScene":
                    SceneManager.LoadScene("StartScene");
                    break;
                case "StartScene":
                    Debug.Log("currentScene");
                    Application.Quit();
                    break;
                case "CarRollScene":
                    SceneManager.LoadScene("GarageScene");
                    break;
            }
            timeSinceClick = 0;
        }
        
    }

}
