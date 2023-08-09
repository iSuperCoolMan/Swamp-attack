using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private Player _player;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        ChangeValue(_player.Wallet.Money);
        _player.Wallet.MoneyChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _player.Wallet.MoneyChanged -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _text.text = value.ToString();
    }
}
