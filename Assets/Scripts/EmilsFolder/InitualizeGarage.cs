using UnityEngine;
using UnityEngine.UI;

public class InitualizeGarage : MonoBehaviour {
    public GameObject MoneyText;
    public GameObject PlayerModel;

    void Awake() {
        MoneyText.GetComponent<Text>().text = $"{PlayerModel.GetComponent<PlayerModel>().NutsBolts} cogweels";
    }

    void Start() {
        Debug.Log(PlayerModel.GetComponent<PlayerModel>().NutsBolts);
        var moneyWon = GameObject.Find("MoneyWon");
        if (moneyWon != null) {
            moneyWon.GetComponent<MoneyWon>().AddToStash();
        }
        Debug.Log(PlayerModel.GetComponent<PlayerModel>().NutsBolts);
        MoneyText.GetComponent<Text>().text = $"{PlayerModel.GetComponent<PlayerModel>().NutsBolts} cogweels";
    }
}
