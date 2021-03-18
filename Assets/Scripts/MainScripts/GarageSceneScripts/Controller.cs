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
    /*
    //RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), Vector2.zero);
    //RaycastHit2D rayHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] rayHit2D = Physics2D.GetRayIntersectionAll(ray, Mathf.Infinity);
            foreach(var hit in rayHit2D)
            {
                if(hit.collider.name == name)
                {
                    var item = hit.collider.GetComponent<Item>();
                    var gButton = hit.collider.CompareTag("GachaButton");

                    if (item)
                    {
                        inventory.AddItem(item.item, 1);
                        Destroy(hit.collider.gameObject);
                    }
                    if (gButton)
                    {
                        RollGachaSoft();
                    }
                }
            }
        }
        */
    public void RollGachaSoft() {
        if (!player.HasEnoughGold(rollCost)) return;
        Debug.Log("Rolled Soft Currency Gacha");
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
            
            Debug.Log(player.gachaLootTableTest[i].name);
            GameObject loot = Instantiate(player.gachaLootTableTest[i], new Vector3(posX, 0, 0), Quaternion.identity) as GameObject; //This is the Loot created.
            loot.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false); // This then place the Gameobject loot into the Canvas.
            //Instantiate(player.gachaLootTableTest[i], new Vector3(posX, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            posX += 150.0f; //Also had to change this since they would spawn ontop of eachother otherwise.
        }
    }
    
    public void RollGachaHard() {
        if (!player.HasEnoughGold(rollCost)) return;
        Debug.Log("Rolled Hard Currency Gacha");
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
            
            Debug.Log(player.gachaLootTableTest[i].name);
            GameObject loot = Instantiate(player.gachaLootTableTest[i], new Vector3(posX, 0, 0), Quaternion.identity) as GameObject;
            loot.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            //Instantiate(player.gachaLootTableTest[i], new Vector3(posX, 0, 0), Quaternion.identity);
            posX += 150.0f;
        }
    }
    
    public void StartRace() {
        SceneManager.LoadScene("CarRollScene");
    }
}