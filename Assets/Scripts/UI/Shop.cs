using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpellView _spellTemplate;
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private GameObject _spellsContainer;

    private void Start()
    {
        foreach (Spell spell in _spells)
            AddSpell(spell);
    }

    private void AddSpell(Spell spell)
    {
        SpellView newSpellView = Instantiate(_spellTemplate, _spellsContainer.transform);

        newSpellView.Render(spell);
        newSpellView.SellButtonClick += OnSellButtonClick;
    }

    private void OnSellButtonClick(Spell spell, SpellView spellView)
    {
        TrySellSpell(spell, spellView);
    }

    private void TrySellSpell(Spell spell, SpellView spellView)
    {
        if (_player.TryBuySpell(spell))
        {
            spellView.LockItem();
            spellView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
