namespace AngbandOS.Core.MonsterSpells;

/// <summary>
/// Represents an immutable set of spells.
/// </summary>
[Serializable]
internal class MonsterSpellList
{
    /// <summary>
    /// Represents all of the spells available to the monster.  This list is immutable and set only in the constructor.
    /// </summary>
    private readonly MonsterSpell[] _spells;

    public MonsterSpell[] Spells => _spells;

    /// <summary>
    /// Returns the spell at a specific index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public MonsterSpell this[int index]
    {
        get => _spells[index];
    }

    /// <summary>
    /// Returns a random spell from the list.
    /// </summary>
    /// <returns></returns>
    public MonsterSpell ChooseRandom()
    {
        return _spells[Program.Rng.RandomLessThan(Count)];

    }

    /// <summary>
    /// Returns a new list of spells that is a subset of the spells with spells that match a predicate excluded.
    /// </summary>
    /// <param name="spellsToRemovePredicate"></param>
    public MonsterSpellList Remove(Func<MonsterSpell, bool> spellsToRemovePredicate)
    {
        return new MonsterSpellList(_spells.Where((_spell) => !spellsToRemovePredicate(_spell)).ToArray());
    }

    /// <summary>
    /// Returns true, if any spells match a predicate; false is none of the spells match the predicate.
    /// </summary>
    /// <param name="qualifyingPredicate"></param>
    /// <returns></returns>
    public bool Contains(Func<MonsterSpell, bool> qualifyingPredicate)
    {
        return _spells.Any(qualifyingPredicate);
    }

    public bool Contains(Type type)
    {
        return _spells.Any((_spell) => type.IsAssignableFrom(_spell.GetType()));
    }

    /// <summary>
    /// Returns a new list of spells that is a subset of the spells with spells that do not match a predicate excluded.
    /// </summary>
    /// <param name="spellsToKeepPredicate"></param>
    /// <returns></returns>
    public MonsterSpellList Where(Func<MonsterSpell, bool> spellsToKeepPredicate)
    {
        return new MonsterSpellList(_spells.Where((_spell) => spellsToKeepPredicate(_spell)).ToArray());
    }

    /// <summary>
    /// Returns a new list of spells with another set of spells concatenated.  Duplicate spells are not removed.
    /// </summary>
    /// <param name="spells"></param>
    /// <returns></returns>
    public MonsterSpellList Add(params MonsterSpell[] spells)
    {
        return new MonsterSpellList(_spells.Concat(spells).ToArray());
    }

    /// <summary>
    /// Returns a new list of spells with another set of spells concatenated.  Duplicate spells are not removed.
    /// </summary>
    /// <param name="spells"></param>
    /// <returns></returns>
    public MonsterSpellList Add(MonsterSpellList spells)
    {
        return new MonsterSpellList(_spells.Concat(spells.Spells).ToArray());
    }

    public MonsterSpellList Distinct()
    {
        return new MonsterSpellList(_spells.Distinct().ToArray());
    }

    /// <summary>
    /// Returns the number of spells in the list.
    /// </summary>
    public int Count => _spells.Length;

    /// <summary>
    /// Constructs a new list of monster spells.
    /// </summary>
    /// <param name="spells"></param>
    public MonsterSpellList(params MonsterSpell[] spells)
    {
        _spells = spells;
    }
}
