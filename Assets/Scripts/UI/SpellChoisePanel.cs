using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SpellChoisePanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpellChoiseView _spellChoiseViewTemplate;

    private List<SpellChoiseView> _spellChoiseViews;
    private int _chosenSpellIndex = 0;

    private void OnEnable()
    {
        _player.Inventory.SpellAdded += AddSpell;
        _player.Inventory.SpellChosen += ChooseSpell;
    }

    private void OnDisable()
    {
        _player.Inventory.SpellAdded -= AddSpell;
        _player.Inventory.SpellChosen -= ChooseSpell;
    }

    private void Awake()
    {
        _spellChoiseViews = new List<SpellChoiseView>();
        AddSpells();
    }

    private void AddSpells()
    {
        IReadOnlyList<Spell> spells = _player.Inventory.Spells;

        for (int i = 0; i < spells.Count; i++)
            AddSpell(spells[i], i);
    }

    private void AddSpell(Spell spell, int index)
    {
        SpellChoiseView newSpell = Instantiate(_spellChoiseViewTemplate, transform);
        newSpell.Render(spell, index);
        _spellChoiseViews.Add(newSpell);
    }

    private void ChooseSpell(int index)
    {
        _spellChoiseViews[_chosenSpellIndex].CancelChoise();
        _chosenSpellIndex = index;
        _spellChoiseViews[_chosenSpellIndex].Choose();
    }
}
