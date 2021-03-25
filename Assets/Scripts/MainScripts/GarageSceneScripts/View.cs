using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {
    public Text cogwheelsField;
    public Text scrapField;
    public PlayerModel player;
    
    private void OnEnable() {
        player.ListenToNutsBoltsChange += UpdateGoldText;
        player.ListenToScrapChange += UpdateScraptext;
        UpdateGoldText(player.NutsBolts);
        UpdateScraptext(player.Scrap);
    }
    
    private void OnDisable() {
        player.ListenToNutsBoltsChange -= UpdateGoldText;
        player.ListenToScrapChange -= UpdateScraptext;
    }
    
    void UpdateGoldText(int playerGold) {
        cogwheelsField.text = $"{player.NutsBolts.ToString()}";
    }
    
    void UpdateScraptext(int playerGold) {
        scrapField.text = $"{player.Scrap.ToString()}";
    }
}