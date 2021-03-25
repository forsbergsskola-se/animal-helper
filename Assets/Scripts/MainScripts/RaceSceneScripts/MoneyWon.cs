using UnityEngine;

public class MoneyWon : MonoBehaviour
{
    private int _money;
    public int moneyPerDistance = 3;
    public int Money {
        get => _money;
        set {
            _money = value / moneyPerDistance;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    
    //called when garage scene starts
    public void AddToStash() {
        GameObject.Find("PlayerModel").GetComponent<PlayerModel>().NutsBolts += Money;
        Destroy(gameObject);
    }
}
