﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class BookItemFactory : ItemFactory
{
    public BookItemFactory(Game game) : base(game) { }

    public override void Bind()
    {
        // We need the base classes to bind.
        base.Bind();

        // Now bind the spells.
        List<Spell> spellList = new List<Spell>();
        foreach (string spellName in SpellNames)
        {
            Spell spell = Game.SingletonRepository.Spells.Get(spellName);
            spellList.Add(spell);
        }
        Spells = spellList.ToArray();
    }

    public void SetBookIndex(Realm realm, int bookIndex)
    {
        BookIndex = bookIndex;
        Realm = realm;
    }

    public int BookIndex { get; private set; }

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    public virtual int ExperienceGainDivisorForDestroying => 4;

    /// <summary>
    /// Returns true for all books.
    /// </summary>
    public override bool EasyKnow => true;

    public abstract string RealmName { get; }

    /// <summary>
    /// Returns the divine title for the book to be returned as the description.  The divine title defaults to the realm name with a "Magic" suffix.
    /// </summary>
    public virtual string DivineTitle => $"{RealmName} Magic";

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavorAware)
    {
        string name = Game.BaseCharacterClass.GetBookTitle(item);
        name = $"{name} {FriendlyName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        int cost = item.Value();
        if (cost <= 50)
        {
            return item.MassRoll(2, 3) + 1;
        }
        if (cost <= 500)
        {
            return item.MassRoll(1, 3) + 1;
        }
        return 0;
    }

    /// <summary>
    /// Returns the singleton realm that this book factory belongs to.
    /// </summary>
    public Realm Realm { get; private set; }

    /// <summary>
    /// Returns the spells that belong to this book.  This property is bound from the SpellNames property during the binding phase.
    /// </summary>
    public Spell[] Spells { get; private set; }

    /// <summary>
    /// Returns the names of the spells that belong to this book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    protected abstract string[] SpellNames { get; }

    /// <summary>
    /// Returns true, if a book is a high level book; false, otherwise.  False is returned, by default.
    /// </summary>
    public virtual bool IsHighLevelBook => false;
}