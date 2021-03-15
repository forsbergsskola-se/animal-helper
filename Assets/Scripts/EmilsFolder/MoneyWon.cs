using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyWon : MonoBehaviour
{
    // Start is called before the first frame update
    public int _Money;
    public int moneyPerDistance = 3;
    public int Money {
        private get {
            return _Money;
        }
        set {
            _Money = value % moneyPerDistance;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    
    //called when garage scene starts
    public void AddToStash() 
    {
        //add money to money stash
        //playermodel.money = Money
        
        // call cool money falling animaton/sound klirr i kassan

        Destroy(this);
    }

    
    
    
}
