using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {
    public Text goldField;
    public PlayerModel player;
    
    private void OnEnable() {
        player.ListenToGoldChange += UpdateGoldText;
        UpdateGoldText(player.Gold);
    }

    private void OnDisable() {
        player.ListenToGoldChange -= UpdateGoldText;
    }

    void UpdateGoldText(int playerGold) {
        goldField.text = player.Gold.ToString();
    }
}