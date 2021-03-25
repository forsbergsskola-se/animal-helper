using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {
    public Text cogwheelsField;
    public Text scrapField;
    public PlayerModel player;
    
    private void OnEnable() {
        player.ListenToGoldChange += UpdateGoldText;
        player.ListenToScrapChange += UpdateScraptext;
        UpdateGoldText(player.Gold);
        UpdateScraptext(player.Scrap);
    }
    
    private void OnDisable() {
        player.ListenToGoldChange -= UpdateGoldText;
        player.ListenToScrapChange -= UpdateScraptext;
    }
    
    void UpdateGoldText(int playerGold) {
        cogwheelsField.text = $"{player.Gold.ToString()}";
    }    
    void UpdateScraptext(int playerGold) {
        scrapField.text = $"{player.Scrap.ToString()}";
    }
}