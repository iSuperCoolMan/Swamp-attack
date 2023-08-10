using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAttack))]
public class Player : Character
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Inventory _inventory;

    public IWallet Wallet => _wallet;
    public IInventory Inventory => _inventory;

    private void Awake()
    {
        GetComponent<PlayerAttack>().Init(_inventory);
    }

    private void Start()
    {
        InitCharacter();
        _inventory.Init();
    }

    private void Update()
    {
        for (int i = 0; i < _inventory.Spells.Count; i++)
        {
            if (Input.GetKeyDown($"{i + 1}"))
                _inventory.ChooseSpell(i);
        }
    }

    public void AddReward(int reward)
    {
        _wallet.AddMoney(reward);
    }

    public bool TryBuySpell(Spell spell)
    {
        if (_wallet.TrySpendMoney(spell.Price))
        {
            _inventory.AddSpell(spell);
            return true;
        }

        return false;
    }
}
