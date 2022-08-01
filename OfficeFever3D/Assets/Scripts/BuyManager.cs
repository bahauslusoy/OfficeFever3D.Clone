using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public int moneyCount  = 0 ;
    private void OnEnable()
    {
        TriggerEventManager.OnMoneyCollect += IncreaseMoney;
    }
    private void OnDisable()
    {
        TriggerEventManager.OnMoneyCollect -= IncreaseMoney;
    }
    void IncreaseMoney()
    {
        moneyCount += 50;
    }
}
