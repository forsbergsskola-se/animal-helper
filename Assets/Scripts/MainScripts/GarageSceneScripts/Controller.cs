using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    
    public int[] weightsSoft = {50, 40, 30, 20, 10, 1};
    public int[] weightsHard = {30, 30, 30, 30, 10, 10};

    public int rollCost = 20;
    public int rewardAmount = 3;
    private float posX;
    private Camera _camera;

    void Start() {
        _camera = Camera.main;
        var moneyWon = GameObject.Find("MoneyWon");
        if (moneyWon != null) {
            moneyWon.GetComponent<MoneyWon>().AddToStash();
        }
    }
    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit)) {
                    var item = hit.collider.GetComponent<Item>();
                    var gButton = hit.collider.CompareTag("GachaButton");
                
                    if (item) {
                        inventory.AddItem(item.item, 1);
                        Destroy(hit.collider.gameObject);
                    }
                    if (gButton) {
                        RollGachaSoft();
                    }
                }
        }
    }

    public void RollGachaSoft() {
        if (!player.HasEnoughGold(rollCost)) return;
        player.Gold -= rollCost;
        posX = -1.5f;
        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weightsSoft.Sum();
            var random = Random.Range(0, totalWeights);

            var total = weightsSoft[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weightsSoft[i];
            }
            
            Debug.Log(player.gachaLootTable[i].name);
            Instantiate(player.gachaLootTable[i], new Vector3(posX, 0, 0), Quaternion.identity);
            posX += 1.5f;
        }
    }
    
    public void RollGachaHard() {
        if (!player.HasEnoughGold(rollCost)) return;
        // Change type of currency
        player.Gold -= rollCost;
        posX = -1.5f;
        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weightsHard.Sum();
            var random = Random.Range(0, totalWeights);

            var total = weightsHard[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weightsHard[i];
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