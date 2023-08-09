using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _healthBar;
    private TMP_Text _healthCount;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<Slider>();
        _healthCount = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _player.Health.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _player.Health.Changed -= ChangeValue;
    }

    public void ChangeValue(int value, int maxValue)
    {
        if (value >= 0)
            _healthBar.value = (float)value / maxValue;
        else
            _healthBar.value = 0;

        _healthCount.text = value.ToString();
    }
}
