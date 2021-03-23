using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
    public InventoryObject inventory;
    public PlayerModel player;
    public CraftingRecipe recipes;
    public GameObject ItemViewPrefab;
    
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
                var gButton = hit.collider.CompareTag("GachaButton");
                if (gButton) {
                    RollGachaHard();
                }                
                var fButton = hit.collider.CompareTag("Fusion");
                if (fButton) {
                    recipes.Craft(inventory);
                }
            }
        }
    }
    
    public void RollGachaSoft() {
        if (!player.HasEnoughGold(rollCost)) return;
        player.Gold -= rollCost;
        posX = 0;
        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weightsSoft.Sum();
            var random = Random.Range(0, totalWeights);
            var total = weightsSoft[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weightsSoft[i];
            }
            
            var go = Instantiate(ItemViewPrefab, new Vector3(470 + posX, 320, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            go.GetComponent<ItemView>().Display(player.gachaLootTable[i]);
            posX += 100f;
        }
    }
    
    public void RollGachaHard() {
        if (!player.HasEnoughGold(rollCost)) return;
        player.Gold -= rollCost;
        posX = 0;
        for (int j = 0; j < rewardAmount; j++) {
            var totalWeights = weightsHard.Sum();
            var random = Random.Range(0, totalWeights);
            var total = weightsHard[0];
            var i = 0;
            while (total < random) { 
                i++; 
                total += weightsHard[i];
            }
            
            var go = Instantiate(ItemViewPrefab, new Vector3(470 + posX, 320, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            go.GetComponent<ItemView>().Display(player.gachaLootTable[i]);
            posX += 100f;
        }
    }
    
    public void StartRace() {
        SceneManager.LoadScene("CarRollScene");
    }
}