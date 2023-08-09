using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Wallet : IWallet
{
    public event UnityAction<int> MoneyChanged;

    public int Money { get; private set; }

    public void AddMoney(int reward)
    {
        Money += reward;
        MoneyChanged?.Invoke(Money);
    }

    public bool TrySpendMoney(int amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            MoneyChanged?.Invoke(Money);
            return true;
        }

        return false;
    }
}
