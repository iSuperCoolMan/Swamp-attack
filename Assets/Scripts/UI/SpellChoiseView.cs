using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellChoiseView : MonoBehaviour
{
    [SerializeField] private Spell _spell;

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _number;

    [SerializeField] private Color _chosenColor;

    private Color _standartColor;

    private void Start()
    {
        _standartColor = _number.color;
    }

    public void Render(Spell spell, int number)
    {
        _spell = spell;

        _icon.sprite = _spell.Icon;
        _number.text = (number + 1).ToString();
    }

    public void Choose()
    {
        _number.faceColor = Color.blue;
    }

    public void CancelChoise()
    {
        _number.faceColor = _standartColor;
    }
}
