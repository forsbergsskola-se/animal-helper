using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {
    public Text cogwheelsField;
    public Text scrapField;
    public PlayerModel player;
    
    private void OnEnable() {
        player.ListenToNutsBoltsChange += UpdateNutsBoltsText;
        player.ListenToScrapChange += UpdateScrapText;
        UpdateNutsBoltsText(player.NutsBolts);
        UpdateScrapText(player.Scrap);
    }
    
    private void OnDisable() {
        player.ListenToNutsBoltsChange -= UpdateNutsBoltsText;
        player.ListenToScrapChange -= UpdateScrapText;
    }
    
    void UpdateNutsBoltsText(int playerNutsBolts) {
        cogwheelsField.text = $"{playerNutsBolts.ToString()}";
    }
    
    void UpdateScrapText(int playerScrap) {
        scrapField.text = $"{playerScrap.ToString()}";
    }
}