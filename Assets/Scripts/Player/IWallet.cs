using UnityEngine.Events;

public interface IWallet
{
    int Money { get; }

    event UnityAction<int> MoneyChanged;

    void AddMoney(int amount);
}
