using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    [SerializeField] Spell _spell;

    [SerializeField] Image _icon;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _description;
    [SerializeField] TMP_Text _attackSpeed;
    [SerializeField] TMP_Text _fireBallsPerShot;
    [SerializeField] TMP_Text _spread;
    [SerializeField] TMP_Text _price;
    [SerializeField] Button _sellButton;

    public event UnityAction<Spell, SpellView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Spell spell)
    {
        _spell = spell;

        _icon.sprite = _spell.Icon;
        _name.text = _spell.Name;
        _description.text = _spell.Description;
        _attackSpeed.text = _spell.AttackSpeed.ToString();
        _fireBallsPerShot.text = _spell.ProjectilesPerShot.ToString();
        _spread.text = _spell.Spread.ToString();
        _price.text = _spell.Price.ToString();
    }

    public void LockItem()
    {
        _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_spell, this);
    }
}
