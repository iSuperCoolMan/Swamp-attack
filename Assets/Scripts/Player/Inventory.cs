using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Inventory : IInventory
{
    [SerializeField] private List<Spell> _spells;

    public event UnityAction<Spell, int> SpellAdded;
    public event UnityAction<int> SpellChosen;

    public IReadOnlyList<Spell> Spells => _spells;

    public void Init()
    {
        ChooseSpell(0);
    }

    public void ChooseSpell(int index)
    {
        if (index >= _spells.Count || index < 0)
            throw new ArgumentOutOfRangeException("Spell index is out of range.");
            
        SpellChosen?.Invoke(index);
    }

    public void AddSpell(Spell spell)
    {
        _spells.Add(spell);
        SpellAdded?.Invoke(spell, _spells.Count - 1);
    }
}
