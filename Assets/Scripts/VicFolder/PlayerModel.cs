using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerModel : MonoBehaviour {
    public InventoryObject inventory;
    public delegate void GoldEvent(int goldValue);
    public event GoldEvent ListenToGoldChange;
    private int _gold = 100;

    private float posX = 0;

    public int Gold {
        get => _gold;
        set {
            _gold = value;
            ListenToGoldChange?.Invoke(value);
        }
    }

    public bool HasEnoughGold(int cost) {
        return Gold >= cost;
    }

    private void Start() {
        inventory.Load();
    }
    
    private void OnApplicationQuit() {
        inventory.Save();
        inventory.Container.Clear();
    }
    
    public GameObject[] items;
    public int[] weights = {50, 40, 30, 20, 10, 1};
    public int rewardAmount = 3;

    public void RollIt() {
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
            
            Debug.Log(items[i].name);
            Instantiate(items[i], new Vector3(posX, 0, 0), Quaternion.identity);
            posX += 1.5f;
        }
    }

}