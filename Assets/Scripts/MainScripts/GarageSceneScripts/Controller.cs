using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    
    public int[] weights = {50, 40, 30, 20, 10, 1};

    public int rollCost = 20;
    public int rewardAmount = 3;
    private float posX;

    void Start() {
        var moneyWon = GameObject.Find("MoneyWon");
        if (moneyWon != null) {
            moneyWon.GetComponent<MoneyWon>().AddToStash();
        }
    }
    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                var item = hit.collider.GetComponent<Item>();
                if (item) {
                    inventory.AddItem(item.item, 1);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    public void RollGacha() {
        if (!player.HasEnoughGold(rollCost)) return;
        player.Gold -= rollCost;
        posX = 0;
        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weights.Sum();
            var random = Random.Range(0, totalWeights);

            var total = weights[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weights[i];
            }
            
            Debug.Log(player.gachaLootTable[i].name);
            Instantiate(player.gachaLootTable[i], new Vector3(posX, 0, 0), Quaternion.identity);
            posX += 1.5f;
        }
    }
    
    public void StartRace() {
        SceneManager.LoadScene("CarRollScene");
    }
}