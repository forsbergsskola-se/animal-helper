using UnityEngine;

public class MoneyWon : MonoBehaviour
{
    // Start is called before the first frame update
    private int _money;
    public int moneyPerDistance = 3;
    public int Money {
        private get {
            return _money;
        }
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
