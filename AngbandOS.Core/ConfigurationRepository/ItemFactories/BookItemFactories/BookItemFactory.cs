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
    public BookItemFactory(SaveGame saveGame) : base(saveGame) { }

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

    public override string GetDescription(Item item, bool includeCountPrefix, bool isFlavourAware)
    {
        string name = SaveGame.BaseCharacterClass.SpellCastingType.GetBookTitle(item);
        name = $"{name} {FriendlyName}";
        return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
    }

    public override int GetAdditionalMassProduceCount(Item item)
    {
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

    public abstract Realm? ToRealm { get; }

    public abstract Spell[] Spells { get; }

    /// <summary>
    /// Returns true, if a book is a high level book; false, otherwise.  False is returned, by default.
    /// </summary>
    public virtual bool IsHighLevelBook => false;
}