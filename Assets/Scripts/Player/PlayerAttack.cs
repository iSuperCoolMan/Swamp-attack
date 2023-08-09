using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    [SerializeField] private Transform _rightArm;
    [SerializeField] private Transform _leftArm;

    private Inventory _inventory;
    private Spell _spell;
    private Coroutine _attack;
    private Dictionary<string, Transform> _attackHands;
    private float _startAnimatorSpeed;

    private void Awake()
    {
        _attackHands = new Dictionary<string, Transform> 
        { 
            { "Attack Right", _rightArm}, 
            { "Attack Left", _leftArm} 
        };

        _startAnimatorSpeed = _handAnimator.speed;
    }

    private void OnEnable()
    {
        _inventory.SpellChosen += ChangeSpell;
    }

    private void OnDisable()
    {
        _inventory.SpellChosen -= ChangeSpell;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            StartAttack();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            StopAttack();
    }

    public void Init(Inventory inventory)
    {
        _inventory = inventory;
        enabled = true;
    }

    public void ChangeSpell(int index)
    {
        _spell = _inventory.Spells[index];
    }

    private void StartAttack()
    {
        _attack = StartCoroutine(Attack());
        _handAnimator.speed = _spell.AttackSpeed / (1f / 2f);
    }

    private void StopAttack()
    {
        StopCoroutine(_attack);
        _handAnimator.speed = _startAnimatorSpeed;
    }

    private IEnumerator Attack()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spell.AttackSpeed);

        while(true)
        {
            foreach(string attackHand in _attackHands.Keys)
            {
                yield return waitForSeconds;
                Shoot(attackHand);
            }
        }
    }

    private void Shoot(string attackHand)
    {
        _handAnimator.SetTrigger(attackHand);
        _spell.Shoot(_attackHands[attackHand]);
    }
}
