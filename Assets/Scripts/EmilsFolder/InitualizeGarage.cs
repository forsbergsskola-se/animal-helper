using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitualizeGarage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MoneyText;
    public GameObject PlayerModel;
    void Start() {
        
        
        Debug.Log(PlayerModel.GetComponent<PlayerModel>().Gold);
        var moneyWon = GameObject.Find("MoneyWon");
        if (moneyWon != null) {
            moneyWon.GetComponent<MoneyWon>().AddToStash();
        }
        Debug.Log(PlayerModel.GetComponent<PlayerModel>().Gold);
        MoneyText.GetComponent<Text>().text = $"{PlayerModel.GetComponent<PlayerModel>().Gold} cogweels";

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
