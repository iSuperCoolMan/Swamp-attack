using System.Collections.Generic;
using UnityEngine.Events;

public interface IInventory
{
    event UnityAction<Spell, int> SpellAdded;
    event UnityAction<int> SpellChosen;

    IReadOnlyList<Spell> Spells { get; }
}
