// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CastingTypes;

/// <summary>
/// Represents basic spell casting properties.
/// </summary>
[Serializable]
internal class CastingType
{
    protected readonly SaveGame SaveGame;
    protected CastingType(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public virtual int Levels => SaveGame.Player.Level;

    /// <summary>
    /// Returns the verb to use for casting.  Returns "cast" by default.  Divine casting type returns "recite".
    /// </summary>
    public virtual string CastVerb => "cast";

    /// <summary>
    /// Returns the noun to use for spells.  Returns "spell" by default.  Divine casting returns "prayer".
    /// </summary>
    public virtual string SpellNoun => "spell";

    /// <summary>
    /// Returns the name for the magic type.  Returns "magic" by default.  Divine casting returns "prayer".
    /// </summary>
    public virtual string MagicType => "magic";

    /// <summary>
    /// Returns true, if the casting type allows the player to choose which spell they want to learn.  Returns true, by default.  Divine
    /// spell casting returns false.
    /// </summary>
    public virtual bool CanChooseSpellToStudy => true;

    /// <summary>
    /// Returns true, if the casting type allows the player to use mana instead of consuming the item.  Returns false, by default.  Channeling
    /// casting type returns true.
    /// </summary>
    public virtual bool CanUseManaInsteadOfConsumingItem => false;

    public virtual string GetBookTitle(BookItem bookItem)
    {
        return $"{bookItem.RealmName} {Pluralize("Spellbook", bookItem.Count)}";
    }
    /// <summary>
    /// Cast a spell.  SaveGame.DoCast is called by default.  Mentalism casting type calls SaveGame.DoMentalism.
    /// </summary>
    public virtual void Cast()
    {
        SaveGame.DoCmdCast();
    }

    /// <summary>
    /// Returns true, if the spell weight of the armour can encumber movement.  Returns false, by default.  Arcane returns true.
    /// </summary>
    public virtual bool WeightEncumbersMovement => false;

    /// <summary>
    /// Returns true, if covered hands with gloves that are not of free-action, dexterity or typespecificvalue == 0 will restrict casting.  Returns false, by default.
    /// Arcane spell casting returns true.
    /// </summary>
    public virtual bool CoveredHandsRestrictCasting => false;
}
