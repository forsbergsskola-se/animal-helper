using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultMenu : MonoBehaviour {
    public Text timeText;
    public Text boltsWonText;

    void OnEnable() {
        var moneyWon = GameObject.Find("MoneyWon").GetComponent<MoneyWon>().Money;
        var raceLength = GameObject.Find("Car(Clone)").GetComponent<MoveCar>().raceLength;
        boltsWonText.text = $"You Won {moneyWon} Bolts n' Nuts!";
        timeText.text = $"Your time: {raceLength}s";
    }
    
    public void RestartRace() {
        SceneManager.LoadScene("CarRollScene");
    }
    
    public void GoToWorkshop() {
        SceneManager.LoadScene("GarageScene");
    }
}
